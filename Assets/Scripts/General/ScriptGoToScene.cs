using UnityEngine;
using System.Collections;

public class ScriptGoToScene : MonoBehaviour {

	public void GoToScene(int number)
	{
		Application.LoadLevel("Test3D");


		/*
		if(number>-1)
		{
			Application.LoadLevel(number);
		}
		
		if(number==-1)
		{
			Application.Quit();
		}
		 * */
	}
}
