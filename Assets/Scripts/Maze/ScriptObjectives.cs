using UnityEngine;
using System.Collections;

public class ScriptObjectives : MonoBehaviour {

	public ScriptMazeEnd m_ScriptMazeEnd;
	public int m_ObjectiveNumber;

	void OnCollisionStay(Collision collision)
	{
		if(collision.gameObject.tag=="Piece")
		{
			m_ScriptMazeEnd.Objective(m_ObjectiveNumber);
			Handheld.Vibrate();
			Destroy(this.gameObject);
			
		}

	}



}
