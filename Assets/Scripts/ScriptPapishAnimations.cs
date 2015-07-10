using UnityEngine;
using System.Collections;

public class ScriptPapishAnimations : MonoBehaviour {

	int m_RandomChoiceAnim;
	public float m_MaxAnimNumber;
	private Animator m_Animator;


	void OnMouseDown ()
	{
		m_RandomChoiceAnim = (int) (UnityEngine.Random.Range (0f,m_MaxAnimNumber));

		m_Animator.SetInteger ("ClickedOn", m_RandomChoiceAnim);

	}
}
