using UnityEngine;
using System.Collections;

public class ConstructionGameManager : MonoBehaviour 
{
	public GameObject[]m_ArrayOfBlocks = new GameObject [6];
	private GameObject m_Instance;
	public float BlockXNumber;

	bool m_Creator = true;

	// Use this for initialization
	/*void Start () 
	{

		for (int i=0; i<m_ArrayOfBlocks.Length; i++) 
		{
			Debug.Log (i);
			RandomBlockXNumber();

			m_Instance=Instantiate(m_ArrayOfBlocks[i],new Vector3 (i*1.5,8,0),transform.rotation) as GameObject;
		}
	
	}
	
	void RandomBlockXNumber ()
	{
		StartCoroutine (C_RandomBlockXNumber());

	}

	IEnumerator C_RandomBlockXNumber()
	{
		yield return new WaitForSeconds (10f);
		BlockXNumber = Random.Range (-7f, 8f);
	}*/

	/*void BlockCreator ()
	{
		StartCoroutine (C_BlockCreator ());
	}

	IEnumerator C_BlockCreator ()
	{
		yield return new WaitForSeconds (0.5f);
		m_Instance=Instantiate(m_ArrayOfBlocks[m_ArrayOfBlocksIndex]) as GameObject;
		//m_Creator = true;
		
	}*/






}
