using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AccelerometerInput : MonoBehaviour {

	public Text m_Text1;
	public Text m_Text2;
	public Text m_Text3;

	public float m_Edge;
	public float m_Offset;

	public float m_x;
	public float m_y;

	private Vector3 m_gyro;
	private Rigidbody m_Rigidbody;
	// Update is called once per frame
	private Vector3 m_InitialPosition;

	void Start()
	{
		m_InitialPosition = transform.position;
		m_Rigidbody = GetComponent<Rigidbody>();
		Input.gyro.enabled = true;
		m_Text1.text = "";
		m_Text2.text = "";
		m_Text3.text = "";

	}

	void Update () 
	{
		
		m_x = (int)(Input.gyro.gravity.x*100);
		m_y = (int)(Input.gyro.gravity.y*100);

		m_Rigidbody.velocity = new Vector3(1 * m_x, 0, 1 * m_y) - m_Rigidbody.velocity*Time.deltaTime;

		m_Text1.text = "X: " + m_x;//+ x ;
		m_Text2.text = "Y: "+ m_y;//+ y;



	}

	public void Reset()
	{
		m_Rigidbody.velocity = new Vector3(0, 0, 0);
		transform.position = m_InitialPosition;

	}

}


//gyro = new Vector3(y, 0, -x);


		/*
		if (transform.rotation.eulerAngles.x < 180)
		{
			if(transform.rotation.eulerAngles.x > 15)
			{
				transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 15);
			}
		}
		else
		{
			if (transform.rotation.eulerAngles.x < 345)
			{
				transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 345);
			}
		}

		if (transform.rotation.eulerAngles.z < 180)
		{
			if (transform.rotation.eulerAngles.z > 15)
			{
				transform.eulerAngles = new Vector3(15, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
			}
		}
		else
		{
			if (transform.rotation.eulerAngles.z < 345)
			{
				transform.eulerAngles = new Vector3(345, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
			}
		}
		*/
		
		
		

		

		/*
		

		if (transform.eulerAngles.x > m_Edge && transform.eulerAngles.x<180)
		{
			transform.eulerAngles = new Vector3(m_Edge, transform.eulerAngles.y, transform.eulerAngles.z);
		}
		else if (transform.eulerAngles.x > 180 && transform.eulerAngles.x < 360-m_Edge)
		{
			transform.eulerAngles = new Vector3(360-m_Edge, transform.eulerAngles.y, transform.eulerAngles.z);
		}
		if (transform.eulerAngles.z > m_Edge && transform.eulerAngles.z < 180)
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, m_Edge);
		}
		else if (transform.eulerAngles.z < 360 - m_Edge && transform.eulerAngles.x > 180)
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 360-m_Edge);
		}
		
		*/

