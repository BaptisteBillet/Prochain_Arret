using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class ScriptEnableDisableAnimator : MonoBehaviour {

	
	private Animator m_Animator;

	void Start()
	{
		m_Animator = GetComponent<Animator>();
	}

	public void EnableAnimator()
	{
		m_Animator.enabled=!m_Animator.enabled;
	}

}
