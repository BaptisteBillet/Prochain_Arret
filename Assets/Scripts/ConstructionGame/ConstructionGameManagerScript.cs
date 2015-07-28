using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class ConstructionGameManagerScript : MonoBehaviour 
{
	public bool m_IsPlaying = true;
	public Text m_TimerText;
	public int m_TimerSeconds;
	public int m_TimerMinutes;
	
	string m_Difficulty;
	
	// Variables pour le Timer

	public GameObject m_PanelUI;
	public GameObject m_PanelTimer;
	public GameObject m_PanelDefeat;
	public GameObject m_PanelVictory;
	public GameObject m_PanelWhirlPool;
	//Variables Panel



	public void Start ()
	{
		m_PanelUI.SetActive (false);
		m_PanelTimer.SetActive (false);
		StartCoroutine (WaitForDifficulty ());
	
	}

	IEnumerator WaitForDifficulty()
	{
		
		m_Difficulty = "";
		switch (Application.platform)
		{
		case RuntimePlatform.Android:
			
			break;
			
		case RuntimePlatform.WindowsPlayer:
			while(PlayerPrefs.GetString("Difficulty")=="NULL")
			{
				yield return new WaitForSeconds(0.5f);
			}
			m_Difficulty = PlayerPrefs.GetString("Difficulty");
			break;
			
		case RuntimePlatform.WindowsEditor:
			while (PlayerPrefs.GetString("Difficulty") == "NULL")
			{
				yield return new WaitForSeconds(0.5f);
			}
			m_Difficulty = PlayerPrefs.GetString("Difficulty");
			break;
			
		}
		//ICI lance l'activité
		
		if (m_Difficulty == "Easy") 
		{
			m_TimerMinutes = 5;
			m_TimerSeconds = 00;
		}
		
		if (m_Difficulty == "Medium") 
		{
			m_TimerMinutes = 3;
			m_TimerSeconds = 30;
		}
		
		if (m_Difficulty == "Hard") 
		{
			m_TimerMinutes = 0;
			m_TimerSeconds = 10;
		}
		
		//Debug.Log (m_Difficulty);

		m_PanelWhirlPool.SetActive (false);

		m_PanelUI.SetActive (true);

		m_PanelTimer.SetActive (true);

		StartCoroutine (TimerCoroutine ());
		


		yield return null;
	}



	public IEnumerator TimerCoroutine()
	{
		
		while (m_TimerMinutes>-1) 
		{
			
			yield return new WaitForSeconds (1f);
			
			if (m_IsPlaying ==true)
			{
				m_TimerText.text = " " + m_TimerMinutes + ":" + m_TimerSeconds;

				if (m_TimerSeconds<10)
				{
					m_TimerText.text = " " + m_TimerMinutes + ":" +"0"+ m_TimerSeconds;
				}
				
				if (m_TimerSeconds == 0) {
					
					if (m_TimerMinutes == 0) {
						GameLost ();
						yield break;
					} else {
						m_TimerSeconds = 60;
						m_TimerMinutes --;
					}
					
				}
				
				if (ScriptObjectifDetection.instance.m_ThirdCheck == true) 
				{
					m_PanelTimer.SetActive (false);
					m_PanelUI.SetActive (false);
					yield break;
				}
				
				m_TimerSeconds --;
			}
		}
		
	}

	public void Pause()
	{
		m_PanelTimer.SetActive (false);
		m_IsPlaying = false;
	}
	
	public void Unpause ()
	{
		m_PanelTimer.SetActive (true);
		m_IsPlaying = true;
	}


	public void GameLost ()
	{
		
		StartCoroutine (C_GameLost ());
	}

	public IEnumerator C_GameLost()
	{
		m_PanelTimer.SetActive (false);
		m_PanelUI.SetActive (false);
		yield return new WaitForSeconds (1f);
		m_PanelDefeat.SetActive (true);
		
	}

}
