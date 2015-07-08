using UnityEngine;
using System.Collections;

public class ScriptPanelAnim : MonoBehaviour {

	private Animator m_Animator;


	// Use this for initialization
	void Start () 
	{
		m_Animator = GetComponent<Animator> ();
	}
	
	public void Bienvenue()
	{
		m_Animator.SetInteger ("SentenceSelect", 8);
	}

	public void Mutte() 
	{
		m_Animator.SetInteger ("SentenceSelect", 0);
	}

	public void Chagall ()
	{
		m_Animator.SetInteger ("SentenceSelect", 1);
	}

	public void Graoully ()
	{
		m_Animator.SetInteger ("SentenceSelect", 2);
	}

	public void Temple ()
	{
		m_Animator.SetInteger ("SentenceSelect", 3);
	}

	public void Vitraux ()
	{
		m_Animator.SetInteger ("SentenceSelect", 4);
	}

	public void Cathedrale ()
	{
		m_Animator.SetInteger ("SentenceSelect", 5);
	}

	public void Gare ()
	{
		m_Animator.SetInteger ("SentenceSelect", 6);
	}

	public void Placedarmes ()
	{
		m_Animator.SetInteger ("SentenceSelect", 7);
	}

	public void Victoire ()
	{
		m_Animator.SetInteger ("SentenceSelect", 9);
	}
	
}
