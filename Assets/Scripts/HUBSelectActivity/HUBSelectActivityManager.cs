using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUBSelectActivityManager : MonoBehaviour
{
	public string m_Designationstring;
	
	int m_Difficulty;
	public Image m_ImageToManage;
	public Sprite[] m_ArrayOfImages= new Sprite [4];
	
	void Start () 
	{
		m_Difficulty = PlayerPrefs.GetInt(m_Designationstring, 0);
		m_ImageToManage.sprite=m_ArrayOfImages[m_Difficulty];
	}


}
