using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptAccelerometerInput : MonoBehaviour
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

	//For the score
	public Text m_Score;
	public Text m_Score1;

	//To know when we stop
	private bool m_stop;


	void Start()
	{
		//Initialisation
		m_stop = false;
		m_InitialPosition = transform.position;
		m_Rigidbody = GetComponent<Rigidbody>();
		Input.gyro.enabled = true;
		StartCoroutine(ScoreCalcul());
		//
	}

	void Update()
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
		if(m_stop==false)
		{
			m_Rigidbody.velocity = new Vector3(1 * m_x, 0, 1 * m_y) - m_Rigidbody.velocity * Time.deltaTime;
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

		}

	}


	//Call when we fall on a hole
	public void Reset()
	{
		//If we are stopped
		if (m_stop == true)
		{
			m_stop = false;
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
	public void Stop()
	{
		m_stop = true;
	}


}

