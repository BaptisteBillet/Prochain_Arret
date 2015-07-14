using UnityEngine;
using System.Collections;

public class ScriptPapishAnimations : MonoBehaviour {

	int m_RandomChoiceAnim;
	public float m_MaxAnimNumber;
	public Animator m_Animator;
	float m_ResetTime;

	bool m_TrendingAnimation = false;

	void OnMouseDown ()
	{
		if (m_TrendingAnimation == false) 
		{
			m_TrendingAnimation = true;
			m_RandomChoiceAnim = (int)(UnityEngine.Random.Range (0f, m_MaxAnimNumber));

			m_Animator.SetInteger ("ClickedOn", m_RandomChoiceAnim);

			m_Animator.SetTrigger ("NewAnimation");

			StopCoroutine (ResetTrendingAnimation());

			StartCoroutine (ResetTrendingAnimation());
		} 


	}

	IEnumerator ResetTrendingAnimation ()
	{
		yield return new WaitForSeconds (1f);
		m_Animator.ResetTrigger ("NewAnimation");
		m_Animator.SetInteger ("ClickedOn", -1);
		m_TrendingAnimation = false;


	}


}
