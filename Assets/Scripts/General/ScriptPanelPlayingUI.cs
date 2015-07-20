using UnityEngine;
using System.Collections;

public class ScriptPanelPlayingUI : MonoBehaviour 
{
	public GameObject m_PanelWhirlpool;
	public GameObject m_PanelPause;


	public void Pause ()
	{
		m_PanelWhirlpool.SetActive (true);
		m_PanelPause.SetActive (true);
	}

}
