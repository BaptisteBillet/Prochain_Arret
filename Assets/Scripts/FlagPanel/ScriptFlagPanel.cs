using UnityEngine;
using System.Collections;

public class ScriptFlagPanel : MonoBehaviour {

	public ScriptFlagWinning m_ScriptFlag;

	public void EndOfAnimation()
	{
		m_ScriptFlag.FlagTransfert();
	}


}
