using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScriptTextSystem : MonoBehaviour {

	//ScriptTextSystem.instance.fonction()

	#region Singleton
	static private ScriptTextSystem s_Instance;
	static public ScriptTextSystem instance
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

	public Animator m_BubbleAnimator1;
	public Animator m_TextAnimator1;
	public Text m_Text1;

	

	public Animator m_BubbleAnimator2;
	public Animator m_TextAnimator2;
	public Text m_Text2;


	
	[Space(10)]
	//Array for the anwser
	public string[] m_ArrayOfText = new string[5];
	public string[] m_ArrayOfText2 = new string[5];
	
	//Affichage
	public void Display1(int TextNumber, float Delay=0)
	{
		StartCoroutine(C_Display1(TextNumber, Delay));
	}
	
	IEnumerator C_Display1(int TextNumber, float Delay)
	{
		yield return new WaitForSeconds(Delay);
		m_Text1.text = "";
		m_BubbleAnimator1.SetTrigger("Reset");
		m_TextAnimator1.SetTrigger("Reset");
		
		yield return new WaitForSeconds(0.2f);
		m_Text1.text = m_ArrayOfText[TextNumber];

	}

	//Effacement
	public void Erase1(float Delay=0)
	{
		StartCoroutine(C_Erase1(Delay));
	}

	IEnumerator C_Erase1(float Delay)
	{
		yield return new WaitForSeconds(Delay);
		m_BubbleAnimator1.SetTrigger("Erase");
		m_TextAnimator1.SetTrigger("Reset");
		m_Text1.text = "";
	}

	//Affichage
	public void Display2(int TextNumber, float Delay = 0)
	{
		StartCoroutine(C_Display2(TextNumber, Delay));
	}

	IEnumerator C_Display2(int TextNumber, float Delay)
	{
		yield return new WaitForSeconds(Delay);
		m_Text2.text = "";
		m_BubbleAnimator2.SetTrigger("Reset");
		m_TextAnimator2.SetTrigger("Reset");

		yield return new WaitForSeconds(0.2f);
		m_Text2.text = m_ArrayOfText[TextNumber];

	}

	//Effacement
	public void Erase2(float Delay = 0)
	{
		StartCoroutine(C_Erase2(Delay));
	}

	IEnumerator C_Erase2(float Delay)
	{
		yield return new WaitForSeconds(Delay);
		m_BubbleAnimator2.SetTrigger("Erase");
		m_TextAnimator2.SetTrigger("Reset");
		m_Text2.text = "";
	}

}
