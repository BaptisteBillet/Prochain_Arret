using UnityEngine;
using System.Collections;

public class ScriptPapishHUB : MonoBehaviour {

	public GameObject m_PanelSelectActivity;
	public GameObject m_PanelHubGeneral;

	public Animator m_Animator;

	void OnMouseDown ()
	{
		ScriptTextSystem.instance.Erase1 ();
		StartCoroutine (SelectActivity ());
	}

	IEnumerator SelectActivity()
	{

		m_PanelHubGeneral.SetActive (false);
		m_Animator.SetTrigger ("ChangePanel");
		yield return new WaitForSeconds (0.1f);
		m_PanelSelectActivity.SetActive (true);
	}

	public void ReturntoHub()
	{
		m_Animator.SetTrigger ("BackToHub");
	}

}
