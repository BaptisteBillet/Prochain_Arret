using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScriptPapishManager : MonoBehaviour {

	public Animator m_Animator;


	// Use this for initialization
	void Start()
	{
		ScriptPapishEventManager.onEvent += LaunchAnim;
	}

	void OnDestroy()
	{
		ScriptPapishEventManager.onEvent -= LaunchAnim;
	}

	public void LaunchAnim(PapishManagerType emt)
	{
		switch (emt)
		{
			case PapishManagerType.IDLE:
				m_Animator.SetTrigger("Idle");
				break;
			case PapishManagerType.VICTORY:
				m_Animator.SetTrigger("Victory");
				break;
			case PapishManagerType.DEFEAT:
				m_Animator.SetTrigger("Defeat");
				break;
		}
	}

	
}
