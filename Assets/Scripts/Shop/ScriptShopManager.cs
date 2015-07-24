using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScriptShopManager : MonoBehaviour 
{
	public GameObject m_Model;

	public Text m_Description;

	public GameObject m_PanelSelect;
	public GameObject m_PanelTenues;
	public GameObject m_PanelMusique;
	public GameObject m_PanelInterface;
	public GameObject m_PanelUI;



	Renderer m_ModelRenderer;

	void Start ()
	{
		m_ModelRenderer = m_Model.GetComponent<Renderer>(); 
		m_Model.SetActive (false);
	}



	public void LoadShopSection (GameObject destination)
	{
		m_PanelSelect.SetActive (false);
		destination.SetActive (true);
		m_PanelUI.SetActive (true);

		if (destination == m_PanelTenues) 
		{
			m_Model.SetActive (true);
		}

	}

	public void ChangeModelAspect (Material newaspect)
	{
		m_ModelRenderer.material = newaspect;
	
	}

	public void ModelAspectDescription (string description)
	{
		m_Description.text = description;
	}




























}
