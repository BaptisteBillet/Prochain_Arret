using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptFlagWinning : MonoBehaviour
{

	public Image m_FlagGO;
	private Image m_FlagInstance;
	[Space(10)]
	public float m_DelayBeforeStart;
	[Space(10)]
	public float m_DelayBetweenFlags;

	// Use this for initialization
	void Start()
	{
		PlayerPrefs.SetInt("FlagsWin", 3);
		StartCoroutine(CreateFlag());
	}

	IEnumerator CreateFlag()
	{
		yield return new WaitForSeconds(m_DelayBeforeStart);

		for (int i = 0; i < PlayerPrefs.GetInt("FlagsWin", 0); i++)
		{
			yield return new WaitForSeconds(m_DelayBetweenFlags);
			m_FlagInstance = Instantiate(m_FlagGO) as Image;
			m_FlagInstance.transform.parent = this.transform;

		}

	}


}