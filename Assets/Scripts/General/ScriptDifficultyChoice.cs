using UnityEngine;
using System.Collections;

public class ScriptDifficultyChoice : MonoBehaviour {

	public Animator m_Animator;

	void Awake()
	{
		switch (Application.platform)
		{
			case RuntimePlatform.Android:
				PlayerPrefs.SetString("Difficulty", "NULL");
				break;

			case RuntimePlatform.WindowsPlayer:
				PlayerPrefs.SetString("Difficulty", "NULL");
				break;

			case RuntimePlatform.WindowsEditor:
				PlayerPrefs.SetString("Difficulty", "NULL");
				break;

		}
	}

	public void SaveDifficulty(string difficulty)
	{
		switch (Application.platform)
		{
			case RuntimePlatform.Android:
				PlayerPrefs.SetString("Difficulty", difficulty);
				break;

			case RuntimePlatform.WindowsPlayer:
				PlayerPrefs.SetString("Difficulty",difficulty);
				break;

			case RuntimePlatform.WindowsEditor:
				PlayerPrefs.SetString("Difficulty",difficulty);
				break;

		}
		m_Animator.SetTrigger("End");
		
	}

	

	/*
	 IEnumerator WaitForDifficulty()
	{
		switch (Application.platform)
		{
			case RuntimePlatform.Android:

				break;

			case RuntimePlatform.WindowsPlayer:
				while(PlayerPrefs.GetString("Difficulty")=="NULL")
				{
					yield return new WaitForSeconds(0.5f);
				}
				break;

			case RuntimePlatform.WindowsEditor:
				while (PlayerPrefs.GetString("Difficulty") == "NULL")
				{
					yield return new WaitForSeconds(0.5f);
				}
				break;

		}
		//ICI lance l'activité
	
	}
	*/

	/*
	 
	switch (Application.platform)
		{
			case RuntimePlatform.Android:

				break;

			case RuntimePlatform.WindowsPlayer:
				switch PlayerPrefs.GetString("Difficulty"):
					{
						case "Easy":
							break;
						case "Medium":
							break;
						case "Hard":
							break;

			case RuntimePlatform.WindowsEditor:
				while (PlayerPrefs.GetString("Difficulty") == "NULL")
				{
					yield return new WaitForSeconds(0.5f);
				}
				break;

		}
	 */
}
