using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScriptShopManager : MonoBehaviour 
{
	public GameObject m_Model;

	public Text m_Description;



	Renderer m_ModelRenderer;

	void Start ()
	{
		m_ModelRenderer = m_Model.GetComponent<Renderer>(); 
	}

	public void ChangeModelAspect(int designation)
	{
		switch (designation) 
		{
		case 0: 
			m_ModelRenderer.material.color = Color.green;
			m_Description.text = "Une magnifique couleur vert emeraude, parfait pour paraitre en soiree."; 
			break;

		case 1: 
			m_ModelRenderer.material.color = Color.red;
			m_Description.text = "Une magnifique couleur vert emeraude, parfait pour paraitre en soiree."; 
			break;

		case 2: 
			m_ModelRenderer.material.color = Color.blue;
			m_Description.text = "Une magnifique couleur vert emeraude, parfait pour paraitre en soiree."; 
			break;

		case 3: 
			m_ModelRenderer.material.color = Color.black;
			m_Description.text = "Une magnifique couleur vert emeraude, parfait pour paraitre en soiree."; 
			break;

		case 4: 
			m_ModelRenderer.material.color = Color.yellow;
			m_Description.text = "Une magnifique couleur vert emeraude, parfait pour paraitre en soiree."; 
			break;

		case 5: 
			m_ModelRenderer.material.color = Color.cyan;
			m_Description.text = "Une magnifique couleur vert emeraude, parfait pour paraitre en soiree."; 
			break;

		case 6: 
			m_ModelRenderer.material.color = Color.magenta;
			m_Description.text = "Une magnifique couleur vert emeraude, parfait pour paraitre en soiree."; 
			break;

		case 7: 
			m_ModelRenderer.material.color = Color.white;
			m_Description.text = "Une magnifique couleur vert emeraude, parfait pour paraitre en soiree."; 
			break;
		}
	}



































}
