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
	//Access to the Bublle Animator
	public Animator m_BubbleAnimator;
	//Access to the QuestionBoard
	public GameObject m_QuestionsBoard;

	//Access to the AnswerBoard
	public GameObject m_AnswerBoard;
	//Access to the AnswerBoard Animator
	public Animator m_AnswerBoardAnimator;

	//Access to the ButtonPanel
	public GameObject m_ButtonPanel;
	//Access to the Ufo Animator
	public Animator m_Ufo1Animator;
	public Animator m_Ufo2Animator;
	public Animator m_Ufo3Animator;
	public Animator m_Ufo4Animator;
	public Animator m_Ufo5Animator;



	//Creation of a List for random quesions
	private List<int> m_QuestionList = new List<int>() { 0, 1, 2, 3, 4 };
	//Keep in memory the Random Number from list
	private int m_QuestionNumberFromList;
	
	//The score
	private int m_Score;
	//The Objectif
	private int m_Goal;
	public int m_GoalEasy;
	public int m_GoalMedium;
	public int m_GoalHard;

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

		StartCoroutine(WaitForDifficulty());
	}

	IEnumerator WaitForDifficulty()
	{
		switch (Application.platform)
		{
			case RuntimePlatform.Android:

				break;

			case RuntimePlatform.WindowsPlayer:
				while(PlayerPrefs.GetString("Difficulty")=="NULL")
				{
					yield return new WaitForSeconds(0.5f);
				}
				break;

			case RuntimePlatform.WindowsEditor:
				while (PlayerPrefs.GetString("Difficulty") == "NULL")
				{
					yield return new WaitForSeconds(0.5f);
				}
				break;

		}
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
		yield return new WaitForSeconds(2f);
		m_BubbleAnimator.SetTrigger("Reset");
		StartQuiz();

	}

	void StartQuiz()
	{
		//No Random
			//We check if they are questions again
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
		else //If not, we check if the player win or loose depend of m_Score and m_Objectif
		{
			if (m_Score >= m_Goal)
			{
				m_BubbleAnimator.SetTrigger("Win");
			}
			else
			{
				m_BubbleAnimator.SetTrigger("Loose");
			}
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
			m_Score++;
			switch(m_QuestionNumberFromList)
			{
				case 1:
					m_Ufo1Animator.SetTrigger("Good");
					break;

				case 2:
					m_Ufo2Animator.SetTrigger("Good");
					break;

				case 3:
					m_Ufo3Animator.SetTrigger("Good");
					break;

				case 4:
					m_Ufo4Animator.SetTrigger("Good");
					break;

				case 5:
					m_Ufo5Animator.SetTrigger("Good");
					break;

			}
		}
		else
		{
			m_BubbleAnimator.SetTrigger("BadAnswer");
			switch (m_QuestionNumberFromList)
			{
				case 1:
					m_Ufo1Animator.SetTrigger("Bad");
					break;

				case 2:
					m_Ufo2Animator.SetTrigger("Bad");
					break;

				case 3:
					m_Ufo3Animator.SetTrigger("Bad");
					break;

				case 4:
					m_Ufo4Animator.SetTrigger("Bad");
					break;

				case 5:
					m_Ufo5Animator.SetTrigger("Bad");
					break;

			}
		}

		yield return new WaitForSeconds(3);
		m_BubbleAnimator.SetTrigger("Reset");
		yield return new WaitForSeconds(0.1f);
		StartQuiz();
	}

	

}



