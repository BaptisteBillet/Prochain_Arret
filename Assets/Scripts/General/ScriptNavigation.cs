using UnityEngine;
using System.Collections;

public class ScriptNavigation : MonoBehaviour {


	public GameObject paneloption;

	public GameObject paneltitre; 

	public GameObject panelpostcards;

	public GameObject PanelPublicPlaces;




	public void Startgame() 
	{
			paneltitre.SetActive (false);
			PanelPublicPlaces.SetActive (true);

	}

	public void Pausegame()
	{
		paneltitre.SetActive (false);
		paneloption.SetActive (true);

	}

	public void UnpauseGame()
	{
		paneloption.SetActive (false);
		paneltitre.SetActive (true);
	}

	public void Metzgame()
	{
		Application.LoadLevel("PostalCardsScreen");
	}
}
