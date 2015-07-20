using UnityEngine;
using System.Collections;

public class ScriptPanelDefeat : MonoBehaviour {

	public void RestartLevel()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	
	public void Return()
	{
		Application.LoadLevel ("PostalCardsScreen");
		
	}
}
