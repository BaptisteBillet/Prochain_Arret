using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScriptQuizzManager : MonoBehaviour {

	#region Singleton
	static private ScriptQuizzManager s_Instance;
	static public ScriptQuizzManager instance
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

	#region Members
	//Access to Papish
	public GameObject m_Papish;
	//Access to the Bubble
	public GameObject m_Bubble;
		public Animator m_BubbleAnimator;

	//Creation of a List for random quesions
	private List<int> m_QuestionList = new List<int>() { 0, 1, 2, 3, 4 };
	//Keep in memory the Random Number from list
	private int m_QuestionNumberFromList;
	
	//The score
	private int m_Score;

	//Access to the QuestionBoard
	public GameObject m_QuestionsBoard;

	//Access to the AnswerBoard
	public GameObject m_AnswerBoard;
	public Animator m_AnswerBoardAnimator;

	public GameObject m_ButtonPanel;


	//Array for the anwser
	public int[] m_ArrayOfAnswers = new int[5];
	#endregion

	void Start()
	{
		#region Initialization
		m_Score = 0;
		m_QuestionNumberFromList = 0;
		m_Papish.SetActive(false);
		m_QuestionsBoard.SetActive(false);
		m_ButtonPanel.SetActive(false);
		#endregion
		
		StartCoroutine(LaunchPapish());
	}

	IEnumerator LaunchPapish()
	{
		//On attend que le fond soit apparu
		yield return new WaitForSeconds(1f);
		//On lance le mouvement de papish
		m_Papish.SetActive(true);
		//On attend la fin du mouvement de papish
		yield return new WaitForSeconds(1f);
		//On le fait parler
		m_Bubble.SetActive(true);
		yield return new WaitForSeconds(3f);
		m_BubbleAnimator.SetTrigger("Reset");
		StartQuiz();

	}

	void StartQuiz()
	{
		if (m_QuestionNumberFromList< 5)
		{
			if (m_ButtonPanel.activeInHierarchy == false)
			{
				m_ButtonPanel.SetActive(true);
			}
			if (m_QuestionsBoard.activeInHierarchy == false)
			{
				m_QuestionsBoard.SetActive(true);
			}

			m_BubbleAnimator.SetInteger("QuestionNumber", m_QuestionNumberFromList + 1);
			m_BubbleAnimator.SetTrigger("NewQuestion");


			if (m_AnswerBoard.activeInHierarchy == false)
			{
				m_AnswerBoard.SetActive(true);
			}

			m_AnswerBoardAnimator.SetInteger("AnswerNumber", m_QuestionNumberFromList + 1);
			m_AnswerBoardAnimator.SetTrigger("NewAnswer");


			m_QuestionNumberFromList++;
		}
		else
		{
			Debug.Log("No More");
		}
		//Random
		/*
		if(m_QuestionList.Count>0)
		{
			m_QuestionNumberFromList = Random.Range(m_QuestionList[0], m_QuestionList.Count);
			m_BubbleAnimator.SetInteger("QuestionNumber", m_QuestionNumberFromList);
			m_QuestionList.Remove(m_QuestionNumberFromList);
			m_BubbleAnimator.SetTrigger("NewQuestion");
		}
		else
		{

		}
		*/
	}

	public void Answer(int AnswerNumber)
	{

		StartCoroutine(GoodAnswer(AnswerNumber));
	}

	public IEnumerator GoodAnswer(int AnswerNumber)
	{
		if(AnswerNumber==m_ArrayOfAnswers[m_QuestionNumberFromList-1])
		{
			m_BubbleAnimator.SetTrigger("GoodAnswer");
		}
		else
		{
			m_BubbleAnimator.SetTrigger("BadAnswer");
		}

		yield return new WaitForSeconds(3);
		m_BubbleAnimator.SetTrigger("Reset");
		StartQuiz();
	}

	

}



