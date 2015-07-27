using UnityEngine;
using System.Collections;

public class ScriptNavigation : MonoBehaviour {


	public GameObject m_Paneloption;

	public GameObject m_paneltitre; 

	public GameObject m_panelpostcards;

	public GameObject m_PanelPublicPlaces;



	public void Startgame() 
	{
			m_paneltitre.SetActive (false);
			m_PanelPublicPlaces.SetActive (true);

	}

	public void Pausegame()
	{
		m_paneltitre.SetActive (false);
		m_Paneloption.SetActive(true);

	}

	public void UnpauseGame()
	{
		m_Paneloption.SetActive(false);
		m_paneltitre.SetActive (true);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void Metzgame()
	{
		Application.LoadLevel("PostalCardsScreen");
	}
}
