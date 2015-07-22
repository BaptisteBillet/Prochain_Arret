using UnityEngine;
using System.Collections;

public class ScriptObjectifDetection : MonoBehaviour {


	#region Singleton
	static private ScriptObjectifDetection s_Instance;
	static public ScriptObjectifDetection instance
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




	public int m_ObjectifNumber;

	public bool m_ThirdCheck=false;

	bool m_AlreadyChecked = false;

	public GameObject m_PanelVictory;
	public GameObject m_PanelWhirlPool;

	PieceScript m_PieceScript;

	void OnTriggerStay (Collider other) 
	{
		if (other.gameObject.tag=="Piece") 
		{
			m_PieceScript = other.gameObject.GetComponent<PieceScript>();
			if (m_PieceScript.m_IsTop == true)
			{
				if (m_AlreadyChecked ==false)
				{
				switch (m_ObjectifNumber)
				{
				case 1: 
					Debug.Log ("OBJ1");
					break;
			
				case 2: 
					Debug.Log ("OBJ2");
					break;
							
				case 3: 
					Debug.Log ("OBJ3");
					m_ThirdCheck = true;

					#region Save
					//Sauvegarde
					int m_LastStep;
					string m_Difficulty;
					int m_Flags;
					int m_FlagsWin;
					m_LastStep = PlayerPrefs.GetInt("MazeDifficulty", 0);
					m_Difficulty = PlayerPrefs.GetString("Difficulty");
					m_Flags = PlayerPrefs.GetInt("Flags");
					m_FlagsWin = 0;
					switch (m_Difficulty)
					{
						case "Easy":
							if (m_LastStep == 0)
							{
								PlayerPrefs.SetInt("MazeDifficulty", 1);
								//Gain de drapeau
								PlayerPrefs.SetInt("Flags", m_Flags++);
								m_FlagsWin++;
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
								PlayerPrefs.SetInt("MazeDifficulty", 2);
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

								PlayerPrefs.SetInt("MazeDifficulty", 3);

							}
							break;
					}

					PlayerPrefs.SetInt("FlagWin", m_FlagsWin);
					#endregion


					m_PanelWhirlPool.SetActive (true);
					m_PanelVictory.SetActive(true);
					break;
				}
				m_AlreadyChecked =true;
				}
			}
		}	
	}
























}
