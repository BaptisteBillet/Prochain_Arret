using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScriptImageSystem : MonoBehaviour 
{

	#region Singleton
	static private ScriptImageSystem s_Instance;
	static public ScriptImageSystem instance
	{
		get
		{
			return s_Instance;
		}
	}
	
	void Awake()
	{
		if (s_Instance == null)
			s_Instance = this;
		//DontDestroyOnLoad(this);
	}
	#endregion

	public Image m_ImageToManage;
	public Sprite[] m_ArrayOfImages= new Sprite [8];

	public void ImageDisplay (int ImageNumber, float Delay=0)
	{
		StartCoroutine (C_ImageDisplay (ImageNumber, Delay));
	}

	IEnumerator C_ImageDisplay (int ImageNUmber, float Delay)
	{
		yield return new WaitForSeconds (Delay);
		m_ImageToManage.sprite = m_ArrayOfImages [ImageNUmber];
	}


}
