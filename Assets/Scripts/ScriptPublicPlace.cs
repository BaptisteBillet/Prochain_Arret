using UnityEngine;
using System.Collections;

public class ScriptPublicPlace : MonoBehaviour 
{
	public GameObject m_PanelPublicPlace;

	public void PublicPlace ()
	{
		AudioListener.volume = 0;
		m_PanelPublicPlace.SetActive (false);
	}

	public void NotPublicPlace ()
	{
		m_PanelPublicPlace.SetActive (false);
	}

}
