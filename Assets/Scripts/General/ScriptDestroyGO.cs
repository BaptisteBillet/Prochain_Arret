using UnityEngine;
using System.Collections;

public class ScriptDestroyGO : MonoBehaviour {

	public GameObject m_Cible;
	public float m_Delay;
	public bool m_Now;

	// Use this for initialization
	void Start () 
	{
		if(m_Now)
		{
			StartCoroutine(C_Destroy());
		}
	}
	
	public void Destroy()
	{
		StartCoroutine(C_Destroy());
	}

	IEnumerator C_Destroy()
	{
		yield return new WaitForSeconds(m_Delay);
		Destroy(m_Cible);
	}

}
