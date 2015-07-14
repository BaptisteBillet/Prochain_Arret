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

	private Animator m_BubbleAnimator;
	private Animator m_TextAnimator;
	private Text m_Text;

	public GameObject m_TextGO;
	
	[Space(10)]
	//Array for the anwser
	public string[] m_ArrayOfText = new string[5];

	void Start()
	{
		m_BubbleAnimator = GetComponent<Animator>();
		m_TextAnimator = m_TextGO.GetComponent<Animator>();
		m_Text = m_TextGO.GetComponent<Text>();
	}


	
	//Affichage
	public void Display(int TextNumber, float Delay=0)
	{
		StartCoroutine(C_Display(TextNumber, Delay));
	}
	
	IEnumerator C_Display(int TextNumber, float Delay)
	{
		yield return new WaitForSeconds(Delay);
		m_Text.text = "";
		m_BubbleAnimator.SetTrigger("Reset");
		m_TextAnimator.SetTrigger("Reset");
		
		yield return new WaitForSeconds(0.2f);
		m_Text.text = m_ArrayOfText[TextNumber];

	}

	//Effacement
	public void Erase(float Delay=0)
	{
		StartCoroutine(C_Erase(Delay));
	}

	IEnumerator C_Erase(float Delay)
	{
		yield return new WaitForSeconds(Delay);
		m_BubbleAnimator.SetTrigger("Erase");
		m_TextAnimator.SetTrigger("Reset");
		m_Text.text = "";
	}
}
