using UnityEngine;
using System.Collections;

public class PieceScript : MonoBehaviour {

	private Vector3 m_ScreenPoint;
	private Vector3 m_Offset;

	public bool m_IsFirst;
	public bool m_IsTop;
	public PieceScript m_PieceScript;

	Renderer m_PieceRenderer;


	Color m_ColorFirstRed = Color.red;
	Color m_ColorTopGreen = Color.green;
	Color m_ColorBaseWhite = Color.white;

	void Start ()
	{
		m_PieceRenderer = GetComponent<Renderer> ();

	}

	void OnMouseDown ()
	{
		m_ScreenPoint = Camera.main.WorldToScreenPoint (this.transform.position);
		m_Offset = this.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, m_ScreenPoint.z));

	}


	void OnMouseDrag ()
	{
		//keep track of the mouse position
		var curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, m_ScreenPoint.z);
	
		//convert the screen mouse position to world point and adjust with offset
		var curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace);
	
		//update the position of the object in the world
		this.transform.position = curPosition;
	}

	void OnCollisionStay(Collision other)
	{ 
		if (other.collider.tag == "Sol") 
		{
			if (m_IsFirst == false) 
			{
				m_IsFirst = true;
				m_PieceRenderer.material.color=m_ColorFirstRed;
			} 
		
			
		}
		if (other.collider.tag == "Piece")
		{
			m_PieceScript = other.gameObject.GetComponent<PieceScript> ();

			if (m_PieceScript.m_IsFirst == true || m_PieceScript.m_IsTop == true) 
			{
				m_IsTop = true;
				m_PieceRenderer.material.color=m_ColorTopGreen;
			}
		}

	}

	void OnCollisionExit (Collision other)
	{
		if (other.collider.tag == "Piece") 
		{
			m_IsTop = false;
		}
		if (other.collider.tag == "Sol") 
		{
			m_IsFirst = false;
		}

		if (m_IsFirst == false && m_IsTop == false) 
		{
			m_PieceRenderer.material.color = m_ColorBaseWhite;
		}

	}



}






