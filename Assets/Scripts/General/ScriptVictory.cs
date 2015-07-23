using UnityEngine;
using System.Collections;

public class ScriptVictory : MonoBehaviour {

	public string m_Destination;
	public GameObject m_PanelFlag;
	[HideInInspector]
	public bool m_IsGoingToHub;

	private int m_FlagWin;

	// Use this for initialization
	public void ReturnToHub()
	{
		m_IsGoingToHub = true;
		Changement();
	}


	public void NextActivity()
	{
		m_IsGoingToHub = false;
		Changement();
	}

	public void Changement()
	{
		m_FlagWin = PlayerPrefs.GetInt("FlagWin");

		if(m_FlagWin>0)
		{
			m_PanelFlag.SetActive(true);
			this.gameObject.SetActive(false);
		}
		else
		{
			if (m_IsGoingToHub == true)
			{
				Application.LoadLevel("HubSelectActivity");
			}
			else
			{
				Application.LoadLevel(m_Destination);
			}
		}

	}

}
