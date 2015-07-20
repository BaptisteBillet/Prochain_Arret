using UnityEngine;
using System.Collections;

public class ScriptEnableDisable : MonoBehaviour {

	public bool m_Animator;
	public float m_DelayAnimator;
	public bool m_FromNowAnimator;
	private Animator m_ComponentAnimator;
	[Space(10)]
	
	public bool m_ThisGameObject;
	public float m_DelayGameObject;
	public bool m_FromNowGameObject;

	void Start()
	{
		if (m_Animator)
		{
			m_ComponentAnimator = GetComponent<Animator>();
			if (m_FromNowAnimator)
			{
				StartCoroutine(DisableAnimator(m_DelayAnimator));
			}
		}

		if (m_FromNowGameObject)
		{
			StartCoroutine(DisableGameObject(m_DelayGameObject));
		}

	}

	public void DisableSomething()
	{
		if (m_Animator)
		{
			StartCoroutine(DisableAnimator(m_DelayAnimator));
		}
		
		if(m_ThisGameObject)
		{
			StartCoroutine(DisableGameObject(m_DelayGameObject));
		}
		
	}

	IEnumerator DisableAnimator(float time)
	{
		yield return new WaitForSeconds(time);
		m_ComponentAnimator.enabled = !m_ComponentAnimator.enabled;
	}

	IEnumerator DisableGameObject(float time)
	{
		yield return new WaitForSeconds(time);
		this.gameObject.SetActive(false);
	}


}
