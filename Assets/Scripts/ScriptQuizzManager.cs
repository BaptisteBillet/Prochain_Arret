using UnityEngine;
using System.Collections;

public class ScriptQuizzManager : MonoBehaviour {

	#region Singleton
	static private ScriptQuizzManager s_Instance;
	static public ScriptQuizzManager instance
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
	

	// Use this for initialization
	void Start () 
	{
		//Initialisation



	}
	
	IEnumerator Openning()
	{


		yield return null;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
