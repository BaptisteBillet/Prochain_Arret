using UnityEngine;
using System.Collections;

public class Navigationscript : MonoBehaviour {


	public GameObject paneloption;

	public GameObject paneltitre; 

	public GameObject panelpostcards;




	public void Startgame() 
	{
			paneltitre.SetActive (false);
			panelpostcards.SetActive (true);

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
