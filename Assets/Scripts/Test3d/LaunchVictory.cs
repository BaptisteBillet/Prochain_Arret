using UnityEngine;
using System.Collections;

public class LaunchVictory : MonoBehaviour {

	public void Victory()
	{
		ScriptPapishEventManager.emit(PapishManagerType.VICTORY);
	}


	public void Defeat()
	{
		ScriptPapishEventManager.emit(PapishManagerType.DEFEAT);
	}
}
