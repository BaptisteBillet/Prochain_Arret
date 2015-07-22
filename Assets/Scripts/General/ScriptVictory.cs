using UnityEngine;
using System.Collections;

public class ScriptVictory : MonoBehaviour {

	public string m_Destination;

	// Use this for initialization
	public void ReturnToHub()
	{
		Application.LoadLevel(m_Destination);
	}


	public void NextActivity()
	{
		Application.LoadLevel(m_Destination);
	}
}
