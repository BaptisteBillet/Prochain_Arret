﻿using UnityEngine;
using System.Collections;

public class ScriptHoleEffect : MonoBehaviour {

	private AccelerometerInput m_AccelerometerInputScript;

	void OnCollisionStay(Collision collision)
	{
		Debug.Log("b");
		if(collision.gameObject.tag=="Ball")
		{
			Debug.Log("a");
			m_AccelerometerInputScript = collision.gameObject.GetComponent<AccelerometerInput>();
			m_AccelerometerInputScript.Reset();
		}
	}


}
