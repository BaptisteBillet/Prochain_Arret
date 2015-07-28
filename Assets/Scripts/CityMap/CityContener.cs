using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CityContener : MonoBehaviour {
	

	private float m_Offset;
	private float m_Distance;
	private Vector3 m_Destination;
	private float m_Delay;
	// Use this for initialization

	public GameObject m_SpotPoint;

	public List<Vector3> m_PositionMap = new List<Vector3>();

	void Start () {
		m_Offset = 46;
		m_Distance = 0.5f;
		m_Delay = 0.00000000001f;
	}

	public void UpSelection(int position)
	{
		transform.position = new Vector3(transform.position.x, transform.position.y - m_Offset, transform.position.z);
		//StartCoroutine(SmoothMovementUp());
		ChangePositionOnTheMap(position);
	}

	public void DownSelection(int position)
	{
		transform.position = new Vector3(transform.position.x, transform.position.y + m_Offset, transform.position.z);
		//StartCoroutine(SmoothMovementDown());
		ChangePositionOnTheMap(position);
	}

	void ChangePositionOnTheMap(int position)
	{
		Debug.Log(position);
		m_SpotPoint.transform.position = m_PositionMap[position];
	}

}
