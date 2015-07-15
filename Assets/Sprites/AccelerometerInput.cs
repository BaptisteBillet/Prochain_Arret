using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AccelerometerInput : MonoBehaviour {

	public Text m_Text1;
	public Text m_Text2;
	public Text m_Text3;

	public float m_Edge;

	private float x;
	private float y;
	private float z;
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
		x = (int)(Input.gyro.gravity.x * 10);
		y = (int)(Input.gyro.gravity.y * 10);
		z = (int)(Input.gyro.gravity.z * 10);

		

		m_Text1.text = "X: "+transform.eulerAngles.x ;//+ x ;
		m_Text2.text = "Y: ";//+ y;
		m_Text3.text = "Z: " + transform.eulerAngles.z;//+ z ;
		 
		//transform.eulerAngles += new Vector3(1, 0, 0) * Time.deltaTime;
		
		
		
		gyro = new Vector3(y, 0, -x);
		transform.eulerAngles += gyro * Time.deltaTime * 10;


		if (transform.eulerAngles.x > m_Edge)
		{
			transform.eulerAngles = new Vector3(m_Edge, transform.eulerAngles.y, transform.eulerAngles.z);
		}
		else if (transform.eulerAngles.x < 360-m_Edge)
		{
			transform.eulerAngles = new Vector3(360-m_Edge, transform.eulerAngles.y, transform.eulerAngles.z);
		}
		if (transform.eulerAngles.z > m_Edge)
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, m_Edge);
		}
		else if (transform.eulerAngles.z < 360-m_Edge)
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 360-m_Edge);
		}
		

	}
}
