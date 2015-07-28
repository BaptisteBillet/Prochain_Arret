using UnityEngine;
using System.Collections;

public class ScriptTitleScreenManager : MonoBehaviour {

	public GameObject m_PanelOption;
	public GameObject m_PanelPublicPlace;
	public GameObject m_PanelTitle;


	public void PauseGame ()
	{
		m_PanelTitle.SetActive (false);
		m_PanelOption.SetActive (true);
	}

	public void StartGame ()
	{
		m_PanelTitle.SetActive (false);
		m_PanelPublicPlace.SetActive (true);
	}

	public void Shop ()
	{
		Debug.Log ("Shop");
	}

	public void Credits ()
	{
		Debug.Log ("Crédits");
	}
	
	public void ReturnToGame ()
	{

		m_PanelOption.SetActive (false);
		m_PanelTitle.SetActive (true);

		
	}


}
