using UnityEngine;
using System.Collections;

public class ScriptFinish : MonoBehaviour {
	private AccelerometerInput m_AccelerometerInputScript;

	void OnTriggerStay(Collider collision)
	{
		
		if (collision.gameObject.tag == "Ball")
		{
			m_AccelerometerInputScript = collision.gameObject.GetComponent<AccelerometerInput>();
			m_AccelerometerInputScript.Stop();
		}
	}

}
