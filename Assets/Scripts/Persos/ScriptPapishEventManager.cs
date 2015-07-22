using UnityEngine;
using System.Collections;

/*
 * Comment émettre un event:
		SoundManagerEvent.emit(EventManagerType.ENEMY_HIT);
 * 
 * Comment traiter un event (dans un start ou un initialisation)
		EventManagerScript.onEvent += (EventManagerType emt, GameObject go) => {
			if (emt == EventManagerType.ENEMY_HIT)
			{
				//SpawnFXAt(go.transform.position);
			}
		};
 * ou:
		void maCallback(EventManagerType emt, GameObject go) => {
			if (emt == EventManagerType.ENEMY_HIT)
			{
				//SpawnFXAt(go.transform.position);
			}
		};
		EventManagerScript.onEvent += maCallback;
 * 
 * qui permet de:
		EventManagerScript.onEvent -= maCallback; //Retire l'appel
 */


public enum PapishManagerType
{
	IDLE,
	VICTORY,
	DEFEAT

}

public class ScriptPapishEventManager : MonoBehaviour
{

	public delegate void EventAction(PapishManagerType emt);
	public static event EventAction onEvent;

	#region Singleton
	static private ScriptPapishEventManager s_Instance;

	static public ScriptPapishEventManager instance
	{
		get
		{
			return s_Instance;
		}
	}
	#endregion


	void Awake()
	{
		if (s_Instance == null)
			s_Instance = this;
		//DontDestroyOnLoad(this);
	}

	void Start()
	{
		ScriptPapishEventManager.onEvent += (PapishManagerType emt) => { Debug.Log(""); };
	}

	public static void emit(PapishManagerType emt)
	{

		if (onEvent != null)
		{
			onEvent(emt);
		}
	}



}
