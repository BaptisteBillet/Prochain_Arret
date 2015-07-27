using UnityEngine;
using System.Collections;

public class ScriptGoToScene : MonoBehaviour {

	public void GoToScene(int number)
	{
		Application.LoadLevel(1);


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
