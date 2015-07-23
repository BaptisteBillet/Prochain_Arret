using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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
	[Space(10)]
	public int m_QuestionNumberFromList;
	//Access to the QuestionBoard
	public GameObject m_QuestionsBoard;
	[Space(10)]
	//Access to the AnswerBoard
	public GameObject m_AnswerBoard;
	[Space(10)]
	//Access to the AnswerBoard Animator
	public Animator m_AnswerBoardAnimator;
	[Space(10)]
	//Access to the images of the answers
	public Animator m_AnswerImageAnimator;
	[Space(10)]
	//Access to the ButtonPanel
	public GameObject m_ButtonPanel;
	[Space(10)]
	//Access to the Ufo Animator
	public Animator m_Ufo1Animator;
	public Animator m_Ufo2Animator;
	public Animator m_Ufo3Animator;
	public Animator m_Ufo4Animator;
	public Animator m_Ufo5Animator;
	[Space(10)]
	//Creation of a List for random quesions
	public List<int> m_QuestionList = new List<int>() { 0, 1, 2, 3, 4 };
	[Space(10)]
	public List<int> m_QuestionRandom = new List<int>() { 0, 1, 2, 3, 4 };
	private int m_IndexOfTheQuestionRandom;
	[Space(10)]
	public int m_QuestionNumber;
	[Space(10)]

	//The score
	private int m_Score;
	[Space(10)]
	//The Objectif
	private string m_Difficulty;
	private int m_Goal;
	[Space(10)]
	public int m_GoalEasy;
	public int m_GoalMedium;
	public int m_GoalHard;
	[Space(10)]
	//Array for the anwser
	public int[] m_ArrayOfAnswers = new int[5];
	[Space(10)]

	public Sprite m_Informations1;
	public Sprite m_Informations2;
	public Sprite m_Informations3;
	public Sprite m_Informations4;
	public Sprite m_Informations5;
	[Space(10)]
	public GameObject m_PanelInformations;
	public Animator m_InformationAnimator;
	public GameObject m_InformationImageGO;
	public Image m_InformationImageSprite;
	public float m_TempsInformation;
	[Space(10)]
	public bool m_ClickButtonPass;
	public GameObject m_InformationButton;
	[Space(10)]
	public GameObject m_PanelButtonAnswer;


	public GameObject m_PanelQuizz;
	public GameObject m_PanelVictory;
	public GameObject m_PanelDefeat;

	#endregion

	void Start()
	{
		#region Initialization
		m_Score = 0;
		m_QuestionNumberFromList = 0;
		m_QuestionNumber = 0;
		m_Papish.SetActive(false);
		m_QuestionsBoard.SetActive(false);
		m_ButtonPanel.SetActive(false);
		m_Goal = -1;
		m_Difficulty = "";
		m_InformationImageSprite = m_InformationImageGO.GetComponent<Image>();
		m_ClickButtonPass = false;
		m_InformationButton.SetActive(false);
		m_PanelButtonAnswer.SetActive(false);
		#endregion
		StartCoroutine(WaitForDifficulty());
	}

	IEnumerator WaitForDifficulty(int a =0)
	{
		switch (Application.platform)
		{
			case RuntimePlatform.Android:
				while(PlayerPrefs.GetString("Difficulty")=="NULL")
				{
					yield return new WaitForSeconds(0.5f);
				}
				m_Difficulty = PlayerPrefs.GetString("Difficulty");
				break;

			case RuntimePlatform.WindowsPlayer:
				while(PlayerPrefs.GetString("Difficulty")=="NULL")
				{
					yield return new WaitForSeconds(0.5f);
				}
				m_Difficulty = PlayerPrefs.GetString("Difficulty");
				break;

			case RuntimePlatform.WindowsEditor:
				while (PlayerPrefs.GetString("Difficulty") == "NULL")
				{
					yield return new WaitForSeconds(0.5f);
				}

				m_Difficulty = PlayerPrefs.GetString("Difficulty");
				break;

		}

		if(m_Difficulty=="Easy")
		{
			m_Goal = m_GoalEasy;
		}
		if(m_Difficulty=="Medium")
		{
			m_Goal = m_GoalMedium;
		}
		if (m_Difficulty == "Hard")
		{
			m_Goal = m_GoalHard;
		}
		m_PanelQuizz.SetActive(true);
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
		ScriptTextSystem.instance.Display1(0);
		yield return new WaitForSeconds(2f);
		
		m_PanelButtonAnswer.SetActive(true);
		StartQuiz();

	}

	void StartQuiz()
	{
		#region NoRandom
		/*
			//We check if they are questions again
		if (m_QuestionNumberFromList< 5)
		{
			//If this is the first question, we activate what that would be
			if (m_ButtonPanel.activeInHierarchy == false)
			{
				m_ButtonPanel.SetActive(true);
			}
			if (m_QuestionsBoard.activeInHierarchy == false)
			{
				m_QuestionsBoard.SetActive(true);
			}
			if (m_AnswerBoard.activeInHierarchy == false)
			{
				m_AnswerBoard.SetActive(true);
			}

			//Write the right question take on the array corresponding whith the question number from list
		
		
			//Reset all animation
		

			//Write the right answer take on the array corresponding whith the question number from list
			m_AnswerBoardAnimator.SetInteger("AnswerNumber", m_QuestionNumberFromList + 1);
			m_AnswerBoardAnimator.SetTrigger("NewAnswer");
			ScriptTextSystem.instance.Display1(m_QuestionNumberFromList+1);
			//Go to the next question
			m_QuestionNumberFromList++;
		}
		else //If not, we check if the player win or loose depend of m_Score and m_Objectif
		{
			if (m_Score >= m_Goal)
			{
				//Victoire
				ScriptTextSystem.instance.Display1(6);
			}
			else
			{
				//Perdu
				ScriptTextSystem.instance.Display1(7);
			}
		
		}
		*/
		#endregion 
		//We check if they are questions again
		if (m_QuestionNumber< 5)
		{
			//If this is the first question, we activate what that would be
			if (m_ButtonPanel.activeInHierarchy == false)
			{
				m_ButtonPanel.SetActive(true);
			}
			if (m_QuestionsBoard.activeInHierarchy == false)
			{
				m_QuestionsBoard.SetActive(true);
			}
			if (m_AnswerBoard.activeInHierarchy == false)
			{
				m_AnswerBoard.SetActive(true);
			}

			m_IndexOfTheQuestionRandom = Random.Range(0, m_QuestionRandom.Count);//Donne un nombre pour choisir une des cases restantes de m_questionRandom
			m_QuestionNumberFromList = m_QuestionRandom[m_IndexOfTheQuestionRandom]; //Prend l'objet dans la case
			m_QuestionRandom.RemoveAt(m_IndexOfTheQuestionRandom); //Enleve la case choisi pour qu'elle ne soit plus réutilisé.
			
			
			//Go to the next question
			m_QuestionNumber++;
			//Write the right answer take on the array corresponding whith the question number from list
			m_AnswerBoardAnimator.SetInteger("AnswerNumber", m_QuestionNumberFromList+1); //Besoin d'un nombre de 1 à 5 donc +1
			m_AnswerBoardAnimator.SetTrigger("NewAnswer");
			ScriptTextSystem.instance.Display1(m_QuestionNumberFromList+1); //Besoin d'un nombre de 1 à 5 donc +1
		}
		else //If not, we check if the player win or loose depend of m_Score and m_Objectif
		{
			if (m_Score >= m_Goal)
			{
				//Victoire
				ScriptTextSystem.instance.Display1(6);

				#region Save
				//Sauvegarde
				int m_LastStep;
				string m_Difficulty;
				int m_Flags;
				int m_FlagsWin;

				/////////////////////
				PlayerPrefs.SetInt("QuizzDifficulty", 0);
				////////////////////

				m_LastStep = PlayerPrefs.GetInt("QuizzDifficulty", 0);
				m_Difficulty = PlayerPrefs.GetString("Difficulty");
				m_Flags = PlayerPrefs.GetInt("Flags");
				m_FlagsWin = 0;
				switch (m_Difficulty)
				{
					case "Easy":
						if (m_LastStep == 0)
						{
							PlayerPrefs.SetInt("QuizzDifficulty", 1);
							//Gain de drapeau
							PlayerPrefs.SetInt("Flags", m_Flags++);
							m_FlagsWin++;
						}
						break;

					case "Medium":
						if (m_LastStep < 2)
						{
							if (m_LastStep == 0)
							{
								PlayerPrefs.SetInt("Flags", m_Flags++);
								m_FlagsWin++;
							}
							m_Flags = PlayerPrefs.GetInt("Flags");
							PlayerPrefs.SetInt("Flags", m_Flags++);
							m_FlagsWin++;
							PlayerPrefs.SetInt("QuizzDifficulty", 2);
							//Gain de drapeau
						}
						break;

					case "Hard":
						if (m_LastStep < 3)
						{
							if (m_LastStep < 2)
							{
								if (m_LastStep < 1)
								{
									m_Flags = PlayerPrefs.GetInt("Flags");
									PlayerPrefs.SetInt("Flags", m_Flags++);
									m_FlagsWin++;
								}
								m_Flags = PlayerPrefs.GetInt("Flags");
								PlayerPrefs.SetInt("Flags", m_Flags++);
								m_FlagsWin++;
							}
							m_Flags = PlayerPrefs.GetInt("Flags");
							PlayerPrefs.SetInt("Flags", m_Flags++);
							m_FlagsWin++;

							PlayerPrefs.SetInt("QuizzDifficulty", 3);

						}
						break;
				}

				PlayerPrefs.SetInt("FlagWin", m_FlagsWin);
				#endregion

				Destroy(m_Papish);
				m_PanelVictory.SetActive(true);
				m_PanelQuizz.SetActive(false);

			}
			else
			{
				//Perdu
				ScriptTextSystem.instance.Display1(7);
				m_PanelDefeat.SetActive(true);
				m_PanelQuizz.SetActive(false);
			}
		
		}
		
	}

	public void Answer(int AnswerNumber)
	{
		StartCoroutine(GoodAnswer(AnswerNumber));
	}

	public IEnumerator GoodAnswer(int AnswerNumber)
	{

		if (AnswerNumber == m_ArrayOfAnswers[m_QuestionNumberFromList])
		{
			
			m_Score++;
			switch (m_QuestionNumber)
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
			SoundManagerEvent.emit(SoundManagerType.RANDOMPOSITIVE);
			ScriptTextSystem.instance.Display1(Random.Range(8, 29));
			
		}
		else
		{
			switch (m_QuestionNumber)
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
			SoundManagerEvent.emit(SoundManagerType.RANDOMNEGATIVE);
			ScriptTextSystem.instance.Display1(Random.Range(29, 49));
		}

		switch(m_QuestionNumberFromList+1)
		{
			case 1:
				m_InformationImageSprite.sprite = m_Informations1;
				break;

			case 2:
				m_InformationImageSprite.sprite = m_Informations2;
				break;

			case 3:
				m_InformationImageSprite.sprite = m_Informations3;
				break;

			case 4:
				m_InformationImageSprite.sprite = m_Informations4;
				break;

			case 5:
				m_InformationImageSprite.sprite = m_Informations5;
				break;
		}


		m_PanelButtonAnswer.SetActive(false);
		//Pour les informations de fin de question
		m_InformationAnimator.SetTrigger("NewInformation");
		//

		m_InformationButton.SetActive(true);
		
		yield return new WaitForSeconds(m_TempsInformation);
		if(m_InformationButton.activeInHierarchy==true)
		{
			NextStep();
		}

		yield return null;
	}

	
	
	public void NextStep()
	{
		m_InformationButton.SetActive(false);
		m_AnswerImageAnimator.SetInteger("AnswerNumber", m_QuestionNumberFromList+1);
		m_AnswerImageAnimator.SetTrigger("Reset");

		m_InformationAnimator.SetTrigger("Reset");

		/*
		m_BubbleAnimator.SetTrigger("Reset");
		m_TextAnimator.SetTrigger("Reset");*/

		m_AnswerImageAnimator.SetTrigger("NewAnswer"); 
		
		m_PanelButtonAnswer.SetActive(true);
		StartQuiz();
	}

}



