using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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
	
	public Vector3 m_LocationFirstElement = new Vector3 (-5f,3f,0f);
	
	public float m_LocationGapX;
	public float m_LocationGapY;
	
	// Variables de placement des cartes
	
	public int m_ArrayX;
	public int m_ArrayY;

	public int m_ArrayOfCardstatus;

	// Variables de constitution de la grille. 



	public List<int> m_NCardList = new List <int>();

	public int m_NCardListIndex;

	//public float m_NCardListIndexMax = 15f;


	public Text m_TimerText;
	public int m_TimerSeconds;
	public int m_TimerMinutes;

	string m_Difficulty;

// Variables pour le Timer

	public GameObject m_PanelAnimPapish;
	private ScriptPanelAnim m_PanelAnimScript;
// Variables pour les animations.

	
	public GameObject[,] m_MemoryArray;
	
	public GameObject [] m_ArrayOfCard = new GameObject[8];


	
	// Use this for initialization
	void Start () 
	{	
		StartCoroutine (WaitForDifficulty ());

		m_CanPlay = false ; 
		m_MemoryArray= new GameObject[m_ArrayX,m_ArrayY];
		m_ArrayOfCardstatus = 0;

		m_ScoreMax = 8;
	
		if (m_Difficulty == "Easy") 
		{
			m_TimerMinutes = 5;
			m_TimerSeconds = 0;
		}

		if (m_Difficulty == "Medium") 
		{
			m_TimerMinutes = 3;
			m_TimerSeconds = 30;
		}

		if (m_Difficulty == "Hard") 
		{
			m_TimerMinutes = 2;
			m_TimerSeconds = 0;
		}



		//Remplit la card list 
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

		m_PanelAnimScript = m_PanelAnimPapish.GetComponent<ScriptPanelAnim> ();


		m_TimerText.text = "" + m_TimerMinutes + m_TimerSeconds;

	}

	IEnumerator WaitForDifficulty()
	{
		m_Difficulty = "";
		switch (Application.platform)
		{
		case RuntimePlatform.Android:
			
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
		StartCoroutine (WaitForBienvenue ());
		GridBuilding ();//lance la création de la grille
	}


	IEnumerator WaitForBienvenue ()
	{
		yield return new WaitForSeconds(1.5f);
		m_PanelAnimScript.Bienvenue ();

	}
	
	void GridBuilding()
	{

		for (int x=0;x<m_ArrayX;x++)
		{
			for(int y=0; y<m_ArrayY; y++)
			{
				m_NCardListIndex = (int)(Random.Range (0f,m_NCardList.Count));

				m_MemoryArray[x,y]=m_ArrayOfCard[m_NCardList[m_NCardListIndex]];

				m_MemoryArray[x,y].transform.position = new Vector3 (m_LocationFirstElement.x +(x*2), m_LocationFirstElement.y + (y*2));
				Instantiate(m_MemoryArray[x,y]);
				m_NCardList.RemoveAt(m_NCardListIndex);
				//m_NCardListIndexMax--;
				if (m_ArrayOfCardstatus>7)
				{
					m_ArrayOfCardstatus=0;
				}

			}
		}
		m_CanPlay = true;



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

				m_PanelAnimScript.DisplayInformation(m_Card.GetComponent<ScriptCard>().m_CardNumber);

				if (m_Score==m_ScoreMax)
				{
					//m_PanelAnimScript.Victoire();
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
		yield return new WaitForSeconds (1f);
		m_TimerSeconds --;
		m_TimerText.text = "" + m_TimerMinutes + m_TimerSeconds;
		if (m_TimerSeconds < -1) 
		{
			m_TimerMinutes --;

			if (m_TimerMinutes < 0) 
			{
				yield return null;
			}
			else 
			{
			m_TimerSeconds = 59;
			}
		}


	}

	
}
