using UnityEngine;
using System.Collections;

public class ScriptInfoFinal : MonoBehaviour {

	public GameObject m_Info1;
	public GameObject m_Info2;
	public GameObject m_Info3;


	public void Button1()
	{
		Debug.Log("a");
		if(m_Info1.activeInHierarchy==false)
		{
			m_Info1.SetActive(true);
		}
		else
		{
			CloseInfo();
		}
		
	}
	public void Button2()
	{
		if (m_Info2.activeInHierarchy == false)
		{
			m_Info2.SetActive(true);
		}
		else
		{
			CloseInfo();
		}
	}
	public void Button3()
	{
		if (m_Info3.activeInHierarchy == false)
		{
			m_Info3.SetActive(true);
		}
		else
		{
			CloseInfo();
		}
	}
	public void CloseInfo()
	{
		m_Info3.SetActive(false);
		m_Info2.SetActive(false);
		m_Info1.SetActive(false);
	}
	public void ReturnToHub()
	{
		Debug.Log("a");
	}
	public void NextStep()
	{
		Debug.Log("a");
	}


}
