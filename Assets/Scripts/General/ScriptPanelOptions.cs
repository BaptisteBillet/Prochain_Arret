using UnityEngine;
using System.Collections;

public class ScriptPanelOptions : MonoBehaviour 
{
	public bool m_FromPause = false; 
	public GameObject m_PanelPause ;

	public void Credits ()
	{
		Debug.Log ("Crédits");
	}

	public void ReturnToGame ()
	{
		this.gameObject.SetActive (false);

		//if (m_FromPause == true)
		//{
			m_PanelPause.SetActive (true);
		//}

	}


}
