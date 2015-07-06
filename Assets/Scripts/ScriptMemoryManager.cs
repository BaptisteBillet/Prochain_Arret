using UnityEngine;
using System.Collections;

public class ScriptMemoryManager : MonoBehaviour 
{
	
	#region Singleton
	static private ScriptMemoryManager s_Instance;
	static public ScriptMemoryManager instance
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


// Plus haut, Sert à créer un singleton. Une instance unique d'une chose

	static public bool m_CanPlay;
	//[HideInInspector]
	public int m_NComparisonCard1;
	public bool m_FirstCard;
	public int m_Score; 
	public int m_ScoreMax;
// Variables utilitaires pour le script 

	public Vector3 m_LocationFirstElement = new Vector3 (-5f,3f,0f);

	public float m_LocationGapX;
	public float m_LocationGapY;

// Variables de placement de la première carte, le placement des autres peut etre géré par une boucle

	public int m_ArrayX;
	public int m_ArrayY;


	public GameObject[,] m_MemoryArray;
	
	public GameObject [] m_ArrayOfCard = new GameObject[8];

	// Use this for initialization
	void Start () 
	{
		m_CanPlay = false; 
		m_MemoryArray= new GameObject[m_ArrayX,m_ArrayY];
		GridBuilding ();
	}


	void GridBuilding()
	{
		for (int x=0;x<m_ArrayX;x++)
		{
			for(int y=0; y<m_ArrayY; y++)
			{
				m_MemoryArray[x,y]=m_ArrayOfCard[0];
				m_MemoryArray[x,y].transform.position = new Vector3 (m_LocationFirstElement.x +(x*2), m_LocationFirstElement.y + (y*2));
				Instantiate(m_MemoryArray[x,y]);
			}
		}
	}
		/*
		for (GameObject go in m_MemoryArray) 
		{
			go=ArrayOfCard[0];
		}
		*/
		//Debug.Log (m_MemoryArray.Length);


		/*for 

		m_MemoryArray [0, 0].transform.position = m_LocationFirstElement;
		*/

	
}
