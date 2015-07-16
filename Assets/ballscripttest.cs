using UnityEngine;
using System.Collections;

public class ballscripttest : MonoBehaviour {

	public Animator m_Anim;

	// Update is called once per frame
	void Update () {

		if (Input.GetKey("up"))
			m_Anim.SetTrigger("Jump");

		if (Input.GetKey("down"))
			m_Anim.SetTrigger("Stop");

		if (Input.GetKey("left"))
			m_Anim.SetTrigger("Stretch");

		if (Input.GetKey("right"))
			m_Anim.SetTrigger("StopStretch");
	}
}
