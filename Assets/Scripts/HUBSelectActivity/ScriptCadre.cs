using UnityEngine;
using System.Collections;

public class ScriptCadre : MonoBehaviour {

	public string m_Designationstring;
	int m_Difficulty;


	void Start () 
	{
		CheckSave ();

	}
	
	public void CheckSave ()
	{

		m_Difficulty = PlayerPrefs.GetInt (m_Designationstring, 0);
			
		switch (m_Difficulty)
		{
		case 0:
			ScriptImageSystem.instance.ImageDisplay (m_Difficulty);
			break;

		case 1:
			ScriptImageSystem.instance.ImageDisplay (m_Difficulty);
			break;

		case 2:
			ScriptImageSystem.instance.ImageDisplay (m_Difficulty);
			break;

		case 3:
			ScriptImageSystem.instance.ImageDisplay (m_Difficulty);
			break;
		}

	}

	public void LoadMaze ()
	{

	}

	public void LoadMemory ()
	{

	}

	public void LoadConstruction ()
	{
	}







}
