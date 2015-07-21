using UnityEngine;
using System.Collections;

public class ScriptHoleEffect : MonoBehaviour {

	private ScriptMazeManager m_AccelerometerInputScript;

	void OnCollisionStay(Collision collision)
	{

		if(collision.gameObject.tag=="Piece")
		{

			m_AccelerometerInputScript = collision.gameObject.GetComponent<ScriptMazeManager>();
			m_AccelerometerInputScript.Reset();
		}
	}


}
