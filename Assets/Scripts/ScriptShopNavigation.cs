using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour 
{
	public GameObject m_PanelSelect;
	public GameObject m_PanelTenues;
	public GameObject m_PanelThemes;
	public GameObject m_PanelMusique;
	public GameObject m_PanelLevel;
	public GameObject m_PanelPay;
	public GameObject m_PanelAd; 

	public void Tenue()
	{

		m_PanelSelect.SetActive (false);
		m_PanelTenues.SetActive (true);
	}

	public void Theme()
	{
		
		m_PanelSelect.SetActive (false);
		m_PanelThemes.SetActive (true);
	}

	public void Musique()
	{
		
		m_PanelSelect.SetActive (false);
		m_PanelMusique.SetActive (true);
	}

	public void Level()
	{
		
		m_PanelSelect.SetActive (false);
		m_PanelLevel.SetActive (true);
	}

	public void Pay()
	{
		
		m_PanelSelect.SetActive (false);
		m_PanelPay.SetActive (true);
	}

	public void Ad()
	{
		
		m_PanelSelect.SetActive (false);
		m_PanelAd.SetActive (true);
	}
}
