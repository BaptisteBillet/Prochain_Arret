using UnityEngine;
using System.Collections;

public class ScriptVisiteManager : MonoBehaviour {

	public float m_WaitDepart;
	public float m_WaitBetween;

	public int m_StoryLine;



	void Start () 
	{
		//ScriptTextSystem.instance.Display1 (0, 1f);
		//StartCoroutine (Attente());// La coroutine n'arrete pas la progression du programme, elle se fait en parallèle. 
		ScriptImageSystem.instance.ImageDisplay (1, 0);
		/*ScriptTextSystem.instance.Display1 (1, m_WaitBetween);
		ScriptTextSystem.instance.Display2 (0,m_WaitBetween*2);
		ScriptTextSystem.instance.Erase2 (m_WaitBetween*3);
		ScriptTextSystem.instance.Display1 (2, m_WaitBetween*3);
		ScriptTextSystem.instance.Display1 (3, m_WaitBetween*4);
		ScriptTextSystem.instance.Display1 (4, m_WaitBetween*5);
		ScriptTextSystem.instance.Display1 (5, m_WaitBetween*6);
		ScriptTextSystem.instance.Display1 (6, m_WaitBetween*7);
		ScriptTextSystem.instance.Display2 (1,m_WaitBetween*8);
		ScriptTextSystem.instance.Erase2 (m_WaitBetween*9);
		ScriptTextSystem.instance.Display1 (7, m_WaitBetween*9);
		ScriptTextSystem.instance.Display1 (8, m_WaitBetween*10);
		ScriptTextSystem.instance.Display1 (9, m_WaitBetween*11);
		ScriptTextSystem.instance.Display1 (10, m_WaitBetween*12);*/
	}
	



}
