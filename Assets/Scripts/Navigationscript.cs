using UnityEngine;
using System.Collections;

public class Navigationscript : MonoBehaviour {


	static public bool gamestart = false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gamestart) 
		{
			Application.LoadLevel("PostalCardsScreen");
		}
	
	}

	public void startgame () 
	{
		gamestart = true;
	}
}
