using UnityEngine;
using System.Collections;

public class ScriptPanelPause : MonoBehaviour 
{
	public GameObject m_PanelOptions;
	public GameObject m_PanelWhirlPool;
	public GameObject m_PanelUI;
	ScriptPanelOptions m_ScriptPanelOptions;

 
	void Start ()
	{
		m_PanelOptions.GetComponent<ScriptPanelOptions> ();
	}

	public void ReloadLevel ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void ResumeGame ()
	{
		m_PanelWhirlPool.SetActive (false);
		this.gameObject.SetActive (false);
		m_PanelUI.SetActive (true);

	}

	public void Exit ()
	{
		Debug.Log ("Exit");
	}

	public void Options ()
	{
		this.gameObject.SetActive (false);
		m_PanelWhirlPool.SetActive (true);
		m_PanelOptions.SetActive (true);
		//m_ScriptPanelOptions.m_FromPause = true;
	}

	public void Shop()
	{
		Debug.Log ("Shop");
	}

}
