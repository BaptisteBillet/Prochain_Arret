using UnityEngine;
using System.Collections;

public class Navigationscript : MonoBehaviour {


	static public bool gamestart = false;

	static public bool gamepause = false;
	

	static public int gamecount; 

	public int lastgamecount;

	// Use this for initialization
	void Start () 
	{

	}

	
	// Update is called once per frame
	void Update () 
	{


		if (gamestart == true)
		{
			lastgamecount=gamecount;
			Application.LoadLevel("PostalCardsScreen");
			gamecount=2;

		}




		if (gamepause==true)
		{
			lastgamecount=gamecount;
			Application.LoadLevel("OptionsScreen");
			gamecount = 0; 
		}






		if (gamecount == 0) 
		{

			if (gamestart) 
			{
				if (lastgamecount == 2) 
				{
					Application.LoadLevel ("PostalCardsScreen");
				}

				if (lastgamecount == 1) 
				{
					Application.LoadLevel ("TitleScreen");
				}
			}

		}

		

	
	}

	public void Startgame() 
	{
		gamestart = true;
	}

	public void Pausegame()
	{
		gamepause = true;

	}
}
