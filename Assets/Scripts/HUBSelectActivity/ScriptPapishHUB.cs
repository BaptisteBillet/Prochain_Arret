using UnityEngine;
using System.Collections;

public class ScriptPapishHUB : MonoBehaviour {

	public GameObject m_PanelSelectActivity;
	public GameObject m_PanelHubGeneral;

	void OnMouseDown ()
	{
		m_PanelHubGeneral.SetActive (false);
		m_PanelSelectActivity.SetActive (true);

	}
}
