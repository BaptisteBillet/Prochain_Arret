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

	public GameObject m_CurrentPanel;

	int m_Price;

	Renderer m_ModelRenderer;
	MeshFilter m_ModelMesh;

	void Start ()
	{
		m_ModelRenderer = m_Model.GetComponent<Renderer>(); 
		m_ModelMesh = m_Model.GetComponent<MeshFilter>(); 
		m_Model.SetActive (false);
	}



	public void LoadShopSection (GameObject destination)
	{
		m_CurrentPanel = destination;
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

	public void ChangeModelAspect2 (Mesh newmesh)
	{
		m_ModelMesh.mesh = newmesh;
		
	}

	public void ChangeModelAspect3 (MeshFilter newmeshfilter)
	{
		m_ModelMesh.mesh = newmeshfilter.mesh;
		
	}

	public void ModelAspectDescription (string description)
	{
		m_Description.text = description;
	}

	public void StockPrice(int price)
	{
		m_Price = price;
	}

	public void Buy ()
	{

		Debug.Log ("Item bought for" + m_Price);
	}

	public void Back()
	{
		m_CurrentPanel.SetActive (false);
		m_PanelUI.SetActive (false);
		m_Model.SetActive (false);
		m_PanelSelect.SetActive (true);

	}






















}
