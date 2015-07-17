using UnityEngine;
using System.Collections;

public class ScriptHoleEffect : MonoBehaviour {

	private ScriptAccelerometerInput m_AccelerometerInputScript;

	void OnCollisionStay(Collision collision)
	{

		if(collision.gameObject.tag=="Ball")
		{

			m_AccelerometerInputScript = collision.gameObject.GetComponent<ScriptAccelerometerInput>();
			m_AccelerometerInputScript.Reset();
		}
	}


}
