using UnityEngine;
using System.Collections;

public class CityButtonUpDown : MonoBehaviour
{
	public bool IsUp;
	public CityButtonSelection m_CityButtonSelection;

	void OnMouseDown()
	{
		if(IsUp)
		{
			m_CityButtonSelection.UpCityButtonSelection();
		}
		else
		{
			m_CityButtonSelection.DownCityButtonSelection();
		}
	}

}
