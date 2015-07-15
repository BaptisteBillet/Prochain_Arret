using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AccelerometerInput : MonoBehaviour {

	public Text m_Text1;
	public Text m_Text2;
	public Text m_Text3;

	public float m_Edge;
	public float m_Offset;

	public float x;
	public float y;
	public float z;
	private Vector3 gyro;

	// Update is called once per frame
	void Start()
	{
		Input.gyro.enabled = true;
		m_Text1.text = "";
		m_Text2.text = "";
		m_Text3.text = "";

	}
	void Update () 
	{
		
		x = (int)(Input.gyro.gravity.x*100);
		y = (int)(Input.gyro.gravity.y*100);
		z = (int)(Input.gyro.gravity.z*100);



		m_Text1.text = "X: " + Input.gyro.gravity.x*100;//+ x ;
		m_Text2.text = "Y: "+ y;//+ y;
		m_Text3.text = "Z: " + z;//+ z ;
		 
		//transform.eulerAngles += new Vector3(1, 0, 0) * Time.deltaTime;
		gyro = new Vector3(y, 0, -x);
		
		transform.eulerAngles = gyro;

		if(transform.eulerAngles.x>15)
		{
			transform.eulerAngles = new Vector3(15, transform.eulerAngles.y, transform.eulerAngles.z);
		}

		if (transform.eulerAngles.z > 15)
		{
			transform.eulerAngles = new Vector3(15, transform.eulerAngles.y, 15);
		}

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


	}
}
