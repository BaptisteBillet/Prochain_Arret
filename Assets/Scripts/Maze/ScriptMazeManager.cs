using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptMazeManager : MonoBehaviour
{

	//Angle du gyroscope
	public float m_x;
	public float m_y;

	//For saving the vector3 of the accelerometer
	private Vector3 m_gyro;
	//We need the rigidbody to apply velocity
	private Rigidbody m_Rigidbody;

	// To save the starting point;
	private Vector3 m_InitialPosition;

	//For the timer
	private int m_Secondes;
	private int m_Minutes;

	//For the difficuly

	public string m_Difficulty;

	public int m_EasySecondes;
	public int m_EasyMinutes;

	public int m_MediumSecondes;
	public int m_MediumMinutes;

	public int m_HardSecondes;
	public int m_HardMinutes;

	private int m_ObjectiveSecondes;
	private int m_ObjectiveMinutes;

	bool m_IsPlaying;

	//Panels
	public GameObject m_PanelUI;
	public GameObject m_PanelDefeat;
	public GameObject m_PanelVictory;
	public GameObject m_PanelWhirlPool;




	//For the score
	public Text m_Score;
	public Text m_Score1;

	//To know when we stop
	private bool m_stop;

	//If the ball can move, usefull for the delay before the player choose the difficulty
	private bool m_CanMove;
	void Start()
	{
		//Initialisation
		m_CanMove = false;
		m_Difficulty = "NULL";
		//

		StartCoroutine(WaitForDifficulty());
	}

	IEnumerator WaitForDifficulty()
	{
		switch (Application.platform)
		{
			case RuntimePlatform.Android:
				while (PlayerPrefs.GetString("Difficulty") == "NULL")
				{
					yield return new WaitForSeconds(0.5f);
				}
				m_Difficulty = PlayerPrefs.GetString("Difficulty");
				break;

			case RuntimePlatform.WindowsPlayer:
				while (PlayerPrefs.GetString("Difficulty") == "NULL")
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

		if (m_Difficulty == "Easy")
		{
			m_ObjectiveSecondes = m_EasySecondes;
			m_ObjectiveMinutes = m_EasyMinutes;
		}
		if (m_Difficulty == "Medium")
		{
			m_ObjectiveSecondes = m_MediumSecondes;
			m_ObjectiveMinutes =  m_MediumMinutes;
		}
		if (m_Difficulty == "Hard")
		{
			m_ObjectiveSecondes = m_HardSecondes;
			m_ObjectiveMinutes =  m_HardMinutes;
		}

		m_PanelWhirlPool.SetActive (false);

		//Post Initialisation
		m_stop = false;
		m_InitialPosition = transform.position;
		m_Rigidbody = GetComponent<Rigidbody>();
		Input.gyro.enabled = true;
		StartCoroutine(ScoreCalcul());
		m_CanMove = true;
		m_IsPlaying = true;
		//Post Initialisation

	}


	void Update()
	{
		if (m_CanMove == true)
		{
			//We take the gyroscope value
			m_x = (int)(Input.gyro.gravity.x * 100);
			m_y = (int)(Input.gyro.gravity.y * 100);

			//For PC debuging 
			if (Input.GetKey("up"))
				m_y = 10;

			if (Input.GetKey("down"))
				m_y = -10;

			if (Input.GetKey("left"))
				m_x = -10;

			if (Input.GetKey("right"))
				m_x = 10;

			//Apply the gyro value to the velocity;
			if (m_stop == false)
			{
				m_Rigidbody.velocity = new Vector3(1 * m_x, 0, 1 * m_y) - m_Rigidbody.velocity * Time.deltaTime;
			}

		}
	}

	IEnumerator ScoreCalcul()
	{
		//Set the value to 0
		m_Secondes = 0;
		m_Minutes = 0;
		m_Score.text = "00" + ":" + "00";

		//During the game
		while (m_stop == false)
		{
			//Each seconds
			m_Score1.text = m_Score.text;
			yield return new WaitForSeconds(1);

			if (m_IsPlaying ==true)
			{
				m_Secondes++;
				if (m_Secondes > 59)
				{
					m_Secondes = 0;
					m_Minutes++;
				}

				m_Score.text = m_Minutes + ":" + m_Secondes;

				//Technique to keep a display value as 00:00
				if (m_Minutes < 10)
				{

					if (m_Secondes < 10)
					{
						m_Score.text = "0" + m_Minutes + ":" + "0" + m_Secondes;
					}
					else
					{
						m_Score.text = "0" + m_Minutes + ":" + m_Secondes;
					}	

				}
				else
				{
					if (m_Secondes < 10)
					{
						m_Score.text = "0" + m_Minutes + ":" + "0" + m_Secondes;
					}
					else
					{
						m_Score.text = "0" + m_Minutes + ":" + m_Secondes;
					}
				}

				if(m_Minutes>=m_ObjectiveMinutes)
				{
					if (m_Secondes >= m_ObjectiveSecondes)
					{
						m_stop = true;
						m_CanMove = false;

						m_PanelUI.SetActive (false);
						m_PanelWhirlPool.SetActive (true);
						m_PanelDefeat.SetActive (true);
					//Condition de défaite
					}
				}


			}


		}

	}


	//Call when we fall on a hole
	public void Reset()
	{
		//If we are stopped
		if (m_stop == true)
		{
			m_stop = false;
			m_CanMove = true; 
			//Restart the coroutine;
			StartCoroutine(ScoreCalcul());
		}
		//Stop the ball
		m_Rigidbody.velocity = new Vector3(0, 0, 0);
		//Return to the start position
		transform.position = m_InitialPosition;
		//Reset the score value
		m_Secondes = 0;
		m_Minutes = 0;
		m_Score.text = "00" + ":" + "00";
		//Feedback vibration
		Handheld.Vibrate();
	}

	//Call when we touch the ending cube

	public void Pause()
	{
		m_IsPlaying = false;
	}
	
	public void Unpause ()
	{
		m_IsPlaying = true;
	}

	public void Stop()
	{
		m_stop = true;
		m_CanMove = false;
	}


}

