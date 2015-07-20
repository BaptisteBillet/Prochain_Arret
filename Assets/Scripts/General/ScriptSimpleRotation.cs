using UnityEngine;
using System.Collections;

public class ScriptSimpleRotation : MonoBehaviour {

	public float m_AxeX;
	public float m_AxeY;
	public float m_AxeZ;
		
	// Update is called once per frame
	void Update () {

		transform.Rotate(Vector3.right * Time.deltaTime * m_AxeX);
		transform.Rotate(Vector3.up * Time.deltaTime * m_AxeY);
		transform.Rotate(Vector3.forward * Time.deltaTime * m_AxeZ);
	}
}
