using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class ScriptAnimationRandom : MonoBehaviour {
	
	private Animator m_Animator;
	private int m_Random;
	 [Tooltip("Need to be superior to 0, equal at the maximum number of animation you want to randomize in the animator")]
	 [Range(1, 99)]
	public int m_Max;
	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator>();
	}

	public void RandomAnimation()
	{
		if (m_Random==0)
		{
			m_Random = Random.Range(1, m_Max + 1);
		}
		else
		{
			m_Random = 0;
		}
		m_Animator.SetInteger("Random", m_Random);
	}
}
