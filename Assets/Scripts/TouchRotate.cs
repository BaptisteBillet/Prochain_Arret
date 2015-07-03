using UnityEngine;
using System.Collections;

public class TouchRotate : MonoBehaviour {

	public GameObject m_MeshMish;
	public float m_RotateSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			if(Input.mousePosition.x>(Screen.width/2))
			{
				m_MeshMish.transform.Rotate(Vector3.up * Time.deltaTime * m_RotateSpeed);

			}
			else
			{
				m_MeshMish.transform.Rotate(Vector3.down * Time.deltaTime * m_RotateSpeed);
			}
		}
	}
}
