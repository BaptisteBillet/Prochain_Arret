using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CityButtonSelection : MonoBehaviour
{
	public List<GameObject> m_ButtonList = new List<GameObject>();
	private CityButton m_CityButtonScript;

	public int m_ActualSelectedButton;

	public CityContener m_CityConteneur;

	// Use this for initialization
	void Start () 
	{
		

		for(int i=0; i<m_ButtonList.Count-1; i++)
		{
			m_CityButtonScript = m_ButtonList[i].GetComponent<CityButton>();
			m_CityButtonScript.m_Number=i;
			m_CityButtonScript.m_CityButtonSelection = this;
		}

	}


	public void UpCityButtonSelection()
	{
		if(m_ActualSelectedButton>0)
		{
			m_ActualSelectedButton--; 
			foreach(GameObject go in m_ButtonList)
			{
				m_CityButtonScript = go.GetComponent<CityButton>();
				m_CityButtonScript.ChangeSelection();
			}
			m_CityConteneur.UpSelection(m_ActualSelectedButton);
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
				m_CityButtonScript = go.GetComponent<CityButton>();
				m_CityButtonScript.ChangeSelection();
			}
			m_CityConteneur.DownSelection(m_ActualSelectedButton);
			//transform.position = new Vector3(transform.position.x, transform.position.y+76f, transform.position.z);
		}

	}

	public void ClickOnButton(int number)
	{
		if (number == m_ActualSelectedButton)
		{
			//Load new scene
		}
		else
		{
			if (number > m_ActualSelectedButton)
			{
				DownCityButtonSelection();
			}
			if (number < m_ActualSelectedButton)
			{
				UpCityButtonSelection();
			}
		}
	}
}
