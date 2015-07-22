using UnityEngine;
using System.Collections;

public class CityButton : MonoBehaviour {

	public int m_Number;

	public CityButtonSelection m_CityButtonSelection;
	private Animator m_Animator;
	public bool m_SelectedNumber;
	void Start()
	{
		m_Animator = GetComponent<Animator>();
		if (m_CityButtonSelection.m_ActualSelectedButton == m_Number)
		{
			m_Animator.SetTrigger("Selected");
			m_SelectedNumber = true;
		}
		else
		{
			m_Animator.SetTrigger("Unselected");
			m_SelectedNumber = false;
		}
	}

	void OnMouseDown()
	{
		m_CityButtonSelection.ClickOnButton(m_Number);
	}

	public void ChangeSelection()
	{
		if (m_CityButtonSelection.m_ActualSelectedButton == m_Number)
		{
			if(m_SelectedNumber==false)
			{
				m_Animator.SetTrigger("Selected");
				m_SelectedNumber = true;
			}
			
		}
		else
		{
			if (m_SelectedNumber == true)
			{
				m_Animator.SetTrigger("Unselected");
				m_SelectedNumber = false;
			}
			
		}
	}

}
