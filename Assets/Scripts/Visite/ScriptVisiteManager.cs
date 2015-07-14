using UnityEngine;
using System.Collections;

public class ScriptVisiteManager : MonoBehaviour {

	public float m_WaitDepart;
	public float m_WaitBetween;

	public int m_StoryLine;

	void Start () 
	{
		StartCoroutine (AttenteDepart());

		ScriptTextSystem.instance.Display1 (0, 0);
		//StartCoroutine (Attente());// La coroutine n'arrete pas la progression du programme, elle se fait en parallèle. 
		Debug.Log ("1");
		ScriptTextSystem.instance.Display1 (1, 0);
	}
	
	IEnumerator AttenteDepart ()
	{
		Debug.Log ("0");
		yield return new WaitForSeconds (1f);
		Debug.Log ("ok");
	}
}
