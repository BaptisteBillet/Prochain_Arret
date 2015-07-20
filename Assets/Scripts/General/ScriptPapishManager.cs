using UnityEngine;
using System.Collections;

public class ScriptPapishManager : MonoBehaviour {

	#region Singleton
	static private ScriptPapishManager s_Instance;
	static public ScriptPapishManager instance
	{
		get
		{
			return s_Instance;
		}
	}
	void Awake()
	{
		if (s_Instance == null)
			s_Instance = this;
		//DontDestroyOnLoad(this);
	}
	#endregion

	public Animator m_Animator;

	public enum PapishAnimation
	{
		IDLE,
		VICTORY
	}

	public void PlayAnimation(PapishAnimation Animation)
	{
		switch(Animation)
		{
			case PapishAnimation.IDLE:
				m_Animator.SetTrigger("Idle");	
				break;

			case PapishAnimation.VICTORY:
				m_Animator.SetTrigger("Victory");
				break;
		}
		

	}


	public void PlaySound(SoundManagerType Sound)
	{
		SoundManagerEvent.emit(Sound);
	}


}
