﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptHubManager : MonoBehaviour 
{
	public GameObject m_PanelSelectActivity;
	public GameObject m_PanelHubGeneral;
	public GameObject m_Papish;

	void Start () 
	{
		ScriptTextSystem.instance.Display1 (0, 1f);
	}

	/*public void LauchSelectActivity()
	{
		m_PanelHubGeneral.SetActive (false);
		m_PanelSelectActivity.SetActive (true);

	}*/

		

	public void LoadNewActivity (string destination)
	{
		Application.LoadLevel (destination);
	}
	
	public void BacktoHub()
	{
		m_PanelSelectActivity.SetActive (false);
		m_PanelHubGeneral.SetActive (true);
		ScriptTextSystem.instance.Display1 (0, 1f);
		m_Papish.GetComponent<ScriptPapishHUB>().ReturntoHub();
	}

	public void LaunchVisite()
	{
		Application.LoadLevel ("Visite");
	}
	
}