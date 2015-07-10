using UnityEngine;
using System.Collections;

public class ScriptTitleTransition : MonoBehaviour {


	public float m_PlayTime;

	public void Play()
	{
		StartCoroutine(CoroutinePlay());
	}

	IEnumerator CoroutinePlay()
	{
		yield return new WaitForSeconds(m_PlayTime);
		Application.LoadLevel(0);
	}

	public void Exit()
	{
		Application.Quit();
	}

}
