using UnityEngine;
using System.Collections;

public class ScriptPanelVictoryMemory : MonoBehaviour
{

	
	public void ReturnToHub()
	{
		Debug.Log("a");
	}
	public void NextStep()
	{
		Debug.Log("a");
	}

	public void NextActivity ()
	{
		Application.LoadLevel ("Maze");
	}
}
