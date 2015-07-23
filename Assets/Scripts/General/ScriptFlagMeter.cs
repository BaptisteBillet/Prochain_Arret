using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptFlagMeter : MonoBehaviour {

	public Text m_FlagMeter;
	// Use this for initialization
	void Start () {

			m_FlagMeter.text = ""+ PlayerPrefs.GetInt ("Flags");

	}
	

}
