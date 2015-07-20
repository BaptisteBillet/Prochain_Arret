using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CityButtonSelection : MonoBehaviour
{
	public List<GameObject> m_ButtonList = new List<GameObject>();
	private CityButton m_CityButtonScript;

	public int m_ActualSelectedButton;

	// Use this for initialization
	void Start () 
	{
	
		for(int i=0; i<m_ButtonList.Count-1; i++)
		{
			m_CityButtonScript = m_ButtonList[i].GetComponent<CityButton>();
			m_CityButtonScript.m_Number=i;
		}

	}


	public void UpCityButtonSelection()
	{
		if(m_ActualSelectedButton>0)
		{
			m_ActualSelectedButton--; 
			foreach(GameObject go in m_ButtonList)
			{
				go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y - 76f, go.transform.position.z);
			}
			//transform.position = new Vector3(transform.position.x, transform.position.y-76f, transform.position.z);
		}
	}
	public void DownCityButtonSelection()
	{
		if (m_ActualSelectedButton < m_ButtonList.Count-1)
		{
			m_ActualSelectedButton++;
			foreach (GameObject go in m_ButtonList)
			{
				go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y + 76f, go.transform.position.z);
			}
			//transform.position = new Vector3(transform.position.x, transform.position.y+76f, transform.position.z);
		}
	}
}
