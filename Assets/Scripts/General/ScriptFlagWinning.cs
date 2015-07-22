using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptFlagWinning : MonoBehaviour
{

	public Animator m_FlagAnimator;
	public Animator m_FlagWinAnimator;
	public int m_Flags;
	public int m_FlagWin;
	public int m_FlagCounter;

	public Text m_TextFlagWinCounter;
	public Text m_TextFlagCounter;

	public int m_Delay;
	private int m_DelayMemory;
	private int m_Step;

	// Use this for initialization
	void Start()
	{
		m_DelayMemory = m_Delay;


		m_Step = 1;
		m_Flags=PlayerPrefs.GetInt("Flags");
		m_FlagWin = PlayerPrefs.GetInt("FlagWin");

		m_FlagCounter = m_Flags - m_FlagWin;


		m_TextFlagWinCounter.text = m_FlagWin.ToString();
		m_TextFlagCounter.text=m_FlagCounter.ToString();
	}

	


	public void AppearFlagPanel()
	{
		m_FlagAnimator.SetTrigger("Appear");
	}

	public void FlagTransfert()
	{
		m_Step = 2;
		StartCoroutine(Transfert());
		
	}

	public void QuickPassed()
	{

		switch(m_Step)
		{
			case 1:
				m_FlagAnimator.SetTrigger("End");
				m_FlagWinAnimator.SetTrigger("End");
				FlagTransfert();
				break;

			case 2:
				m_Delay = 0;
				break;

			case 3:
				m_FlagAnimator.SetTrigger("Out");
				m_FlagWinAnimator.SetTrigger("Out");
				FlagTransfert();
				break;
		}

	
	}

	IEnumerator Transfert ()
	{
		if (m_FlagWin>0)
		{
			m_FlagWin--;
			m_FlagCounter++;

			

		}
		m_TextFlagWinCounter.text = m_FlagWin.ToString();
		m_TextFlagCounter.text = m_FlagCounter.ToString();
		while(m_FlagWin>0)
		{
			yield return new WaitForSeconds(m_Delay);
			m_FlagWin--;
			m_FlagCounter++;

			m_TextFlagWinCounter.text = m_FlagWin.ToString();
			m_TextFlagCounter.text = m_FlagCounter.ToString();

		}

		yield return new WaitForSeconds(1);

		m_FlagAnimator.SetTrigger("Out");
		m_FlagWinAnimator.SetTrigger("Out");

		m_Step = 3;

		yield return new WaitForSeconds(2);
		//SORTIE


	}


}