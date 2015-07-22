using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptMazeEnd: MonoBehaviour {
	private ScriptMazeManager m_AccelerometerInputScript;

	public bool m_Objective1;
	public bool m_Objective2;
	public bool m_Objective3;

	public GameObject m_Image1;
	public GameObject m_Image2;
	public GameObject m_Image3;
	public GameObject m_Image11;
	public GameObject m_Image22;
	public GameObject m_Image33;

	public GameObject m_PanelWhirlPool;
	public GameObject m_PanelVictory;
	public GameObject m_PanelUI;

	private Renderer m_Renderer;
	private Color m_Green = Color.green;
	private Color m_Red = Color.red;

	

	void Start()
	{
		
		m_Renderer = GetComponent<Renderer>();
		m_Renderer.material.color = m_Red;
	}

	void OnTriggerStay(Collider collision)
	{
		if (collision.gameObject.tag == "Piece")
		{
			if (m_Objective1 && m_Objective2 && m_Objective3)
			{
				m_PanelWhirlPool.SetActive(true);

				m_AccelerometerInputScript = collision.gameObject.GetComponent<ScriptMazeManager>();
				m_AccelerometerInputScript.Stop();
				m_PanelUI.SetActive(false);

				#region Save
				//Sauvegarde
				int m_LastStep;
				string m_Difficulty;
				int m_Flags;
				int m_FlagsWin;
				/////////////////////////////

				PlayerPrefs.SetInt("MazeDifficulty", 0);


				/////////////////////////////
				m_LastStep=PlayerPrefs.GetInt("MazeDifficulty",0);
				m_Difficulty=PlayerPrefs.GetString("Difficulty");
				m_Flags = PlayerPrefs.GetInt("Flags");
				m_FlagsWin = 0;
				switch (m_Difficulty)
				{
					case "Easy":
						if(m_LastStep==0)
						{
							PlayerPrefs.SetInt("MazeDifficulty", 1);
							//Gain de drapeau
							PlayerPrefs.SetInt("Flags", m_Flags++);
							m_FlagsWin++;
						}
						break;

					case "Medium":
						if (m_LastStep <2)
						{
							if (m_LastStep == 0)
							{
								PlayerPrefs.SetInt("Flags", m_Flags++);
								m_FlagsWin++;
							}
							m_Flags = PlayerPrefs.GetInt("Flags");
							PlayerPrefs.SetInt("Flags", m_Flags++);
							m_FlagsWin++;
							PlayerPrefs.SetInt("MazeDifficulty", 2);
							//Gain de drapeau
						}
						break;

					case "Hard":
						if (m_LastStep <3)
						{
							if (m_LastStep < 2)
							{
								if (m_LastStep < 1)
								{
									m_Flags = PlayerPrefs.GetInt("Flags");
									PlayerPrefs.SetInt("Flags", m_Flags++);
									m_FlagsWin++;
								}
								m_Flags = PlayerPrefs.GetInt("Flags");
								PlayerPrefs.SetInt("Flags", m_Flags++);
								m_FlagsWin++;
							}
							m_Flags = PlayerPrefs.GetInt("Flags");
							PlayerPrefs.SetInt("Flags", m_Flags++);
							m_FlagsWin++;

							PlayerPrefs.SetInt("MazeDifficulty", 3);
							
						}
						break;
				}

				PlayerPrefs.SetInt("FlagWin", m_FlagsWin);
				#endregion
				m_PanelVictory.SetActive(true);
			}
		}
	}


	public void Objective(int i)
	{
		switch(i)
		{
			case 1:
				m_Objective1 = true;
				m_Image1.SetActive(true);
				m_Image11.SetActive(true);
				//m_Image111.SetActive(true);
				break;
			
			case 2:
				m_Objective2 = true;
				m_Image2.SetActive(true);
				m_Image22.SetActive(true);
				//m_Image222.SetActive(true);
				break;
			
			case 3:
				m_Objective3 = true;
				m_Image3.SetActive(true);
				m_Image33.SetActive(true);
				//m_Image333.SetActive(true);
				break;
		}

		if (m_Objective1 && m_Objective2 && m_Objective3)
		{
			m_Renderer.material.color = m_Green;
		}

	}


}
