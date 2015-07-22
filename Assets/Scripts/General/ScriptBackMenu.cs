using UnityEngine;
using System.Collections;

public class ScriptBackMenu : MonoBehaviour {

	public void BackToTitle()
	{
		Application.LoadLevel("TitleScreen");
	}
}
