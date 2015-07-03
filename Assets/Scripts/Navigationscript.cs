using UnityEngine;
using System.Collections;

public class Navigationscript : MonoBehaviour {


	public bool gamestart = false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gamestart) 
		{
			Application.LoadLevel("ecrancartespostales");
		}
	
	}

	public void startgame () 
	{
		gamestart = true;
	}
}
