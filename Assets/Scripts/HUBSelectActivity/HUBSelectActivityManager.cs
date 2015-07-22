using UnityEngine;
using System.Collections;

public class HUBSelectActivityManager : MonoBehaviour {

	#region Singleton
	static private HUBSelectActivityManager s_Instance;
	static public HUBSelectActivityManager instance
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
	




	public int m_MemorySaveInt;
	public int m_MazeSaveInt;
	public int m_ConstructionGameSaveInt;
	public int m_QuizzSaveInt;
// Variable de stockage des gains de drapeaux du joueur dans une activité.


	// Use this for initialization
	void Start () 
	{
		CheckSave ();

	}

	public void CheckSave ()
	{
		m_MemorySaveInt = PlayerPrefs.GetInt ("MemoryDifficulty", 0);
		
		m_MazeSaveInt = PlayerPrefs.GetInt ("MazeDifficulty", 0);
		
		m_ConstructionGameSaveInt = PlayerPrefs.GetInt ("ConstructionGameDifficulty", 0);
		
		m_QuizzSaveInt = PlayerPrefs.GetInt ("QuizzDifficulty", 0);
	}

}
