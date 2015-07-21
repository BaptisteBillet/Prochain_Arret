using UnityEngine;
using System.Collections;

public class ScriptObjectifDetection : MonoBehaviour {


	#region Singleton
	static private ScriptObjectifDetection s_Instance;
	static public ScriptObjectifDetection instance
	{
		get
		{
			return s_Instance;
		}
	}
	#endregion
	
	
	void Awake()
	{
		if (s_Instance == null)
			s_Instance = this;
		//DontDestroyOnLoad(this);
	}




	public int m_ObjectifNumber;

	public bool m_ThirdCheck=false;

	bool m_AlreadyChecked = false;

	public GameObject m_PanelVictory;

	PieceScript m_PieceScript;

	void OnTriggerStay (Collider other) 
	{
		if (other.gameObject.tag=="Piece") 
		{
			m_PieceScript = other.gameObject.GetComponent<PieceScript>();
			if (m_PieceScript.m_IsTop == true)
			{
				if (m_AlreadyChecked ==false)
				{
				switch (m_ObjectifNumber)
				{
				case 1: 
					Debug.Log ("OBJ1");
					break;
			
				case 2: 
					Debug.Log ("OBJ2");
					break;
							
				case 3: 
					Debug.Log ("OBJ3");
					m_ThirdCheck = true;
					m_PanelVictory.SetActive(true);
					break;
				}
				m_AlreadyChecked =true;
				}
			}
		}	
	}
























}
