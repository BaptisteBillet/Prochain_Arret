using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;


public class ScriptMemoryManager : MonoBehaviour 
{
	
	#region Singleton
	static private ScriptMemoryManager s_Instance;
	static public ScriptMemoryManager instance
	{
		get
		{
			return s_Instance;
		}
	}
	#endregion
	
	
	void Awake()
	{
		if (s_Instance == null)
			s_Instance = this;
		//DontDestroyOnLoad(this);
	}
	
	
	// Plus haut, Sert à créer un singleton. Une instance unique d'une chose
	
	public bool m_CanPlay;
	//[HideInInspector]
	public int m_NComparisonCard1;
	GameObject m_Card;
	public bool m_FirstCard;
	public int m_Score; 
	public int m_ScoreMax;
	// Variables utilitaires pour le script 

	public Vector3 m_LocationFirstElement;
	public float m_LocationGapX;
	public float m_LocationGapY;
	
	// Variables de placement des cartes
	
	public int m_ArrayX;
	public int m_ArrayY;
	
	public int m_ArrayOfCardstatus;
	
	// Variables de constitution de la grille. 
	

	public GameObject m_PanelUI;

	// Variables Panel 
	
	public List<int> m_NCardList = new List <int>();
	
	public int m_NCardListIndex;
	
	//public float m_NCardListIndexMax = 15f;


	public GameObject m_PanelWhirlPool;
	public GameObject m_PanelPapishReact;

	public bool m_IsPlaying = true;
	public Text m_TimerText;
	public int m_TimerSeconds;
	public int m_TimerMinutes;
	
	string m_Difficulty;
	
	// Variables pour le Timer
	
	public GameObject m_PanelAnimPapish;

	// Variables pour les animations.
	

	public GameObject m_PanelDefeat;
	private ScriptCard m_ScriptCard;
	public GameObject m_PanelVictory;
	// Variables fin de niveau, défaites
	public GameObject[,] m_MemoryArray;
	
	public GameObject [] m_ArrayOfCard = new GameObject[8];
	

	
	// Use this for initialization
	void Start () 
	{	//Remplit la card list 
		
		m_PanelUI.SetActive (false);

		m_NCardList.Add (7);
		m_NCardList.Add (6);	
		m_NCardList.Add (5);	
		m_NCardList.Add (4);
		m_NCardList.Add (3);	
		m_NCardList.Add (2);	
		m_NCardList.Add (1);
		m_NCardList.Add (0);
		
		m_NCardList.Add (7);
		m_NCardList.Add (6);	
		m_NCardList.Add (5);	
		m_NCardList.Add (4);
		m_NCardList.Add (3);	
		m_NCardList.Add (2);	
		m_NCardList.Add (1);
		m_NCardList.Add (0);

		m_CanPlay = false ; 
		m_MemoryArray= new GameObject[m_ArrayX,m_ArrayY];
		m_ArrayOfCardstatus = 0;



		m_ScoreMax = 8;






		m_PanelPapishReact.SetActive(false);
		m_TimerText.text=""+ m_TimerMinutes + m_TimerSeconds;

		StartCoroutine (WaitForDifficulty ());
		

		
	}
	 
	IEnumerator WaitForDifficulty()
	{

		m_Difficulty = "";
		switch (Application.platform)
		{
		case RuntimePlatform.Android:
			while(PlayerPrefs.GetString("Difficulty")=="NULL")
			{
				yield return new WaitForSeconds(0.5f);
			}
			m_Difficulty = PlayerPrefs.GetString("Difficulty");

			break;
			
		case RuntimePlatform.WindowsPlayer:
			while(PlayerPrefs.GetString("Difficulty")=="NULL")
			{
				yield return new WaitForSeconds(0.5f);
			}
			m_Difficulty = PlayerPrefs.GetString("Difficulty");
			break;
			
		case RuntimePlatform.WindowsEditor:
			while (PlayerPrefs.GetString("Difficulty") == "NULL")
			{
				yield return new WaitForSeconds(0.5f);
			}
			m_Difficulty = PlayerPrefs.GetString("Difficulty");
			break;
			
		}
		//ICI lance l'activité
		
		if (m_Difficulty == "Easy") 
		{
			m_TimerMinutes = 3;
			m_TimerSeconds = 30;
		}
		
		if (m_Difficulty == "Medium") 
		{
			m_TimerMinutes = 2;
			m_TimerSeconds = 0;
		}
		
		if (m_Difficulty == "Hard") 
		{
			m_TimerMinutes = 1;
			m_TimerSeconds = 0;
		}
		
		//Debug.Log (m_Difficulty);

		m_PanelWhirlPool.SetActive (false);

		StartCoroutine (WaitForBienvenue ());
	
		GridBuilding ();//lance la création de la grille


		yield return null;
	}
	
	
	IEnumerator WaitForBienvenue ()
	{

		yield return new WaitForSeconds(0.5f);
		m_PanelUI.SetActive (true);
		m_PanelPapishReact.SetActive(true);
		yield return new WaitForSeconds(0.7f);


		//m_PanelAnimScript.Bienvenue ();
		ScriptTextSystem.instance.Display2(8);
		
	}
	
	void GridBuilding()
	{

		for (int x=0;x<m_ArrayX;x++)
		{
			for(int y=0; y<m_ArrayY; y++)
			{

				m_NCardListIndex = (int)(UnityEngine.Random.Range (0f,m_NCardList.Count));
				//Debug.Log (m_NCardListIndex);

				m_MemoryArray[x,y]=m_ArrayOfCard[m_NCardList[m_NCardListIndex]];

				m_MemoryArray[x, y].transform.position = new Vector3(m_LocationFirstElement.x + (x * 2), m_LocationFirstElement.y - (y * 2), -6);

				Instantiate(m_MemoryArray[x, y]);

				m_MemoryArray[x,y].transform.position = new Vector3 (m_LocationFirstElement.x +(x*2), m_LocationFirstElement.y - (y*2), -6);
				
			

				Debug.Log(m_MemoryArray[x, y].transform.position);

				m_NCardList.RemoveAt(m_NCardListIndex);
				//m_NCardListIndexMax--;

				if (m_ArrayOfCardstatus>7)
				{
					m_ArrayOfCardstatus=0;
				}

				
			}
		}

		m_CanPlay = true;
		
		StartCoroutine (TimerCoroutine ());
				
	}
	
	public void StartCompare(GameObject LastClickedCard)
	{
		StartCoroutine(Compare (LastClickedCard));
	}
	

	
	public IEnumerator Compare (GameObject LastClickedCard)
	{
		
		if (m_FirstCard == true) 
		{
			m_Card = LastClickedCard;
			m_FirstCard = false;
			
		} 
		else 
		{
			
			
			if (m_Card.GetComponent<ScriptCard>().m_CardNumber==LastClickedCard.GetComponent<ScriptCard>().m_CardNumber)
			{
				
				m_Score++;

				ScriptTextSystem.instance.Display2 (m_Card.GetComponent<ScriptCard>().m_CardNumber);

				//m_PanelAnimScript.DisplayInformation(m_Card.GetComponent<ScriptCard>().m_CardNumber);
				
				if (m_Score==m_ScoreMax)
				{
					m_PanelUI.SetActive (false);
					m_IsPlaying = false;
					//m_PanelAnimScript.Victoire();
					yield return new WaitForSeconds (5f);
					ScriptTextSystem.instance.Erase2();
					yield return new WaitForSeconds (1f);


					#region Save
					//Sauvegarde
					int m_LastStep;
					string m_Difficulty;
					int m_Flags;
					int m_FlagsWin;

					/////////////////////////////////////
					//PENSER A ENLEVER
					PlayerPrefs.SetInt("MemoryDifficulty", 0);
					/////////////////////////////////////
					m_LastStep = PlayerPrefs.GetInt("MemoryDifficulty", 0);
					m_Difficulty = PlayerPrefs.GetString("Difficulty");
					m_Flags = PlayerPrefs.GetInt("Flags");
					m_FlagsWin = 0;

					Debug.Log(m_Difficulty);
					Debug.Log(PlayerPrefs.GetInt("MemoryDifficulty", 0));
					switch (m_Difficulty)
					{
						case "Easy":
							if (m_LastStep == 0)
							{
								PlayerPrefs.SetInt("MemoryDifficulty", 1);
								//Gain de drapeau
								PlayerPrefs.SetInt("Flags", m_Flags++);
								m_FlagsWin++;
								Debug.Log("a");
							}
							break;

						case "Medium":
							if (m_LastStep < 2)
							{
								if (m_LastStep == 0)
								{
									PlayerPrefs.SetInt("Flags", m_Flags++);
									m_FlagsWin++;
								}
								m_Flags = PlayerPrefs.GetInt("Flags");
								PlayerPrefs.SetInt("Flags", m_Flags++);
								m_FlagsWin++;
								PlayerPrefs.SetInt("MemoryDifficulty", 2);
								//Gain de drapeau
							}
							break;

						case "Hard":
							if (m_LastStep < 3)
							{
								if (m_LastStep < 2)
								{
									if (m_LastStep < 1)
									{
										m_Flags = PlayerPrefs.GetInt("Flags");
										PlayerPrefs.SetInt("Flags", m_Flags++);
										m_FlagsWin++;
									}
									m_Flags = PlayerPrefs.GetInt("Flags");
									PlayerPrefs.SetInt("Flags", m_Flags++);
									m_FlagsWin++;
								}
								m_Flags = PlayerPrefs.GetInt("Flags");
								PlayerPrefs.SetInt("Flags", m_Flags++);
								m_FlagsWin++;

								PlayerPrefs.SetInt("MemoryDifficulty", 3);

							}
							break;
					}

					PlayerPrefs.SetInt("FlagWin", m_FlagsWin);
					#endregion

					Debug.Log(m_FlagsWin);

					m_PanelPapishReact.SetActive(false);
					m_PanelWhirlPool.SetActive (true);
					m_PanelVictory.SetActive(true);

				}

				
			}
			
			else 
			{
				m_CanPlay = false ; 
				yield return new WaitForSeconds (1f);
				
				m_Card.GetComponent<ScriptCard>().FlipBack();
				LastClickedCard.GetComponent<ScriptCard>().FlipBack();
				
			}


			m_Card = null;
			m_FirstCard=true;
			m_CanPlay = true;
			
		}
		yield return null;
	}
	

	
	
	
	public IEnumerator TimerCoroutine()
	{

			while (m_TimerMinutes>-1) 
		{

				yield return new WaitForSeconds (1f);

			if (m_IsPlaying ==true)
			{
				m_TimerText.text = " " + m_TimerMinutes + ":" + m_TimerSeconds;

				if (m_TimerSeconds<10)
				{
					m_TimerText.text = " " + m_TimerMinutes + ":" +"0"+ m_TimerSeconds;
				}

				if (m_TimerSeconds == 0) {
				
					if (m_TimerMinutes == 0) {
						GameLost ();
						yield break;
					} else {
						m_TimerSeconds = 60;
						m_TimerMinutes --;
					}

				}

				if (m_Score == m_ScoreMax) {
					yield break;
				}

				m_TimerSeconds --;
			}
			}

}


	public void GameLost ()
	{

		StartCoroutine (C_GameLost ());



	}
	public IEnumerator C_GameLost()
	{

		for (int x=0; x<m_ArrayX; x++) 
		{
			for (int y=0; y<m_ArrayY; y++) 
			{
				m_PanelUI.SetActive (false);
				ScriptTextSystem.instance.Erase2();
				m_ScriptCard= m_MemoryArray[x,y].GetComponent<ScriptCard>();
				m_ScriptCard.CardFall();
			}
		}

		yield return new WaitForSeconds (1f);
		m_PanelDefeat.SetActive (true);
		
	}

	public void Pause()
	{
		m_PanelPapishReact.SetActive(false);
		ScriptTextSystem.instance.Erase2();
		m_IsPlaying = false;
	}

	public void Unpause ()
	{
		m_PanelPapishReact.SetActive(true);
		m_IsPlaying = true;
	}

}
