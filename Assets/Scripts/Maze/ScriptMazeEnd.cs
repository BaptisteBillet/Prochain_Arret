using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptMazeEnd: MonoBehaviour {
	private ScriptAccelerometerInput m_AccelerometerInputScript;

	public bool m_Objective1;
	public bool m_Objective2;
	public bool m_Objective3;

	public Image m_Image1;
	public Image m_Image2;
	public Image m_Image3;

	void OnTriggerStay(Collider collision)
	{
		if (collision.gameObject.tag == "Ball")
		{
			if (m_Objective1 && m_Objective2 && m_Objective3)
			{
				m_AccelerometerInputScript = collision.gameObject.GetComponent<ScriptAccelerometerInput>();
				m_AccelerometerInputScript.Stop();
			}
		}
	}


	public void Objective(int i)
	{
		switch(i)
		{
			case 1:
				m_Objective1 = true;
				m_Image1.enabled = false;
				break;
			
			case 2:
				m_Objective2 = true;
				m_Image2.enabled = false;
				break;
			
			case 3:
				m_Objective3 = true;
				m_Image3.enabled = false;
				break;


		}
	}


}
