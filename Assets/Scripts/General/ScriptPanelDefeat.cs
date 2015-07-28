using UnityEngine;
using System.Collections;

public class ScriptPanelDefeat : MonoBehaviour {

	public GameObject m_PanelWhirlPool;


	public void Start() 
	{
		m_PanelWhirlPool.SetActive (true);
	}

	public void RestartLevel()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	
	public void Return()
	{
		Application.LoadLevel ("HubSelectActivity");
	}
}
