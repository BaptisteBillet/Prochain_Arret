using UnityEngine;
using System.Collections;

public class ScriptPanelAnim : MonoBehaviour {

	public Animator m_Animator;
	public float m_ResetTime;
	public float m_ResetTimeBienvenue;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	public void Bienvenue()
	{
		m_Animator.SetTrigger ("Bienvenue");
		//StartCoroutine (Reset (m_ResetTimeBienvenue));
	}

	public void DisplayInformation(int bubble) 
	{
		//Debug.Log (bubble);
		m_Animator.SetTrigger ("Reset");	
		m_Animator.SetTrigger ("NewInformation");
		m_Animator.SetInteger ("SentenceSelect", bubble);
		//StartCoroutine (Reset(m_ResetTime));

	}
	

	public IEnumerator Reset (float time)
	{
		if (time == -1) 
		{
			time = m_ResetTime;
		}
			yield return new WaitForSeconds (time);
		m_Animator.SetTrigger ("Reset");	
	}

	public void Victoire()
	{
		m_Animator.SetTrigger ("Victoire");

	}

	public void ResetLaunch ()
	{
		StartCoroutine (Reset (m_ResetTime));
	}

}
