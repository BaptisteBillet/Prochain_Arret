using UnityEngine;
using System.Collections;

public class ScriptFlagWinPanel : MonoBehaviour
{
	public ScriptFlagWinning m_ScriptFlag;
	// Use this for initialization

	public void EndOfAnimation()
	{
		m_ScriptFlag.AppearFlagPanel();
		
	}
}
