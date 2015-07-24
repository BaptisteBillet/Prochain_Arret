using UnityEngine;
using System.Collections;

public class PieceScript : MonoBehaviour {

	private Vector3 m_ScreenPoint;
	private Vector3 m_Offset;

	public bool m_IsFirst;
	public bool m_IsTop;
	public PieceScript m_PieceScript;

	Vector3 point;

	Renderer m_PieceRenderer;

	Collider m_Collider;
	Rigidbody m_RigidBody;

	//ConstructionGameManagerScript m_CGMS;


	Color m_ColorFirstRed = Color.red;
	Color m_ColorTopGreen = Color.green;
	Color m_ColorBaseWhite = Color.white;

	void Start ()
	{
		m_PieceRenderer = GetComponent<Renderer> ();
		m_Collider = GetComponent<BoxCollider>();
		m_RigidBody = GetComponent<Rigidbody>();
	}


	void OnMouseDrag ()
	{
		point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	
		transform.position = new Vector3 (point.x,point.y,1);
		m_Collider.enabled = false;
		m_RigidBody.useGravity = false;

	}

	void OnMouseUp ()
	{
		m_Collider.enabled = true;
		m_RigidBody.useGravity = true;
	}
	void Update ()
	{
		if (this.transform.position.x > 8.7f) 
		{
			this.transform.position = new Vector3 (8.7f,transform.position.y,transform.position.z);
		}

		if (this.transform.position.x < -8.7f) 
		{
			this.transform.position = new Vector3 (-8.7f,transform.position.y,transform.position.z);
		}
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





/*void OnMouseDown ()
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
*/

