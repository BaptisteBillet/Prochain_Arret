﻿using UnityEngine;
using System.Collections;

public class ScriptCard : MonoBehaviour 
{
	public int m_CardNumber;

	private bool m_CanBeClick=true;
	public Animator m_Animator;

	void Start () 
	{
		//m_Animator = GetComponent<Animator>();

	}


	void OnMouseDown ()
	{
		if (m_CanBeClick == true && ScriptMemoryManager.instance.m_CanPlay == true) 
		{
			m_CanBeClick=false;
			m_Animator.SetTrigger("Flip1");
			ScriptMemoryManager.instance.StartCompare(this.gameObject); 


		}
	}

	public void FlipBack()

	{
		m_Animator.SetTrigger ("Flip2");
		m_CanBeClick = true;

	}

	public void CardArrival ()
	{
		m_Animator.SetTrigger ("Arriving");
	}

	public void CardFall()
	{

		m_Animator.SetTrigger ("GameLost");
	}

	void OnBecameInvisible ()

	{
		Destroy (this);

	}

}