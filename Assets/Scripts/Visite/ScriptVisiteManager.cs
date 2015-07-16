using UnityEngine;
using System.Collections;

public class ScriptVisiteManager : MonoBehaviour {

	public float m_WaitDepart;
	public float m_WaitBetween;
	public float m_WaitSupImage;

	float m_Waiting;

	int m_NumberSequence;
	int m_WaitFactor;

	void Start () 
	{
		m_NumberSequence = 0;
		m_WaitFactor = 1;
		StartCoroutine (WaitImage ());
		m_Waiting = m_WaitBetween * m_WaitFactor;
	}
	
	IEnumerator WaitImage ()
	{
		yield return new WaitForSeconds (1f);
		ScriptTextSystem.instance.Display1 (0);
		SoundPlay(0);


		yield return new WaitForSeconds (5f);
		ScriptTextSystem.instance.Display1 (1);
		SoundPlay(1);


		yield return new WaitForSeconds (13f);
		ScriptTextSystem.instance.Display1 (2);
		SoundPlay(2);


		yield return new WaitForSeconds (17f);
		ScriptTextSystem.instance.Display1 (3);
		SoundPlay(3);


		yield return new WaitForSeconds (9f);
		ScriptTextSystem.instance.Display1 (4);
		SoundPlay(4);

		
		yield return new WaitForSeconds (9f);
		ScriptTextSystem.instance.Display1 (5);
		SoundPlay(5);
		
		yield return new WaitForSeconds (9f);
		ScriptTextSystem.instance.Display1 (6);
		SoundPlay(6);
		
		yield return new WaitForSeconds (9f);
		ScriptTextSystem.instance.Display1 (7);
		SoundPlay(7);
		
		yield return new WaitForSeconds (9f);
		ScriptTextSystem.instance.Display1 (8);
		SoundPlay(8);
		
		yield return new WaitForSeconds (9f);
		ScriptTextSystem.instance.Display1 (9);
		SoundPlay(9);
		
		yield return new WaitForSeconds (9f);
		ScriptTextSystem.instance.Display1 (10);
		SoundPlay(10);
		
		ScriptTextSystem.instance.Erase1 ();


	}

	IEnumerator MishSpeak (int Number)
	{
		switch (Number) {
		case 1: 

			m_WaitFactor=2;
			ScriptTextSystem.instance.Display2 (0, m_WaitBetween); //Oooooh
			yield return new WaitForSeconds (m_WaitBetween);
			ScriptTextSystem.instance.Erase2();
			break;

		case 6: 
			yield return new WaitForSeconds (m_WaitBetween);
			ScriptTextSystem.instance.Display2 (1, m_WaitBetween); //Oooooh
			break;

		}
	}





	void SoundPlay (int Number)
	{
		switch (Number) 
		{
		case 0:
			Debug.Log ("Sound");
			SoundManagerEvent.emit (SoundManagerType.TURMEL00);
			break;
		case 1:
			SoundManagerEvent.emit (SoundManagerType.TURMEL01);
			break;
		case 2:
			SoundManagerEvent.emit (SoundManagerType.TURMEL02);
			break;
		case 3:
			SoundManagerEvent.emit (SoundManagerType.TURMEL03);
			break;
		case 4:
			SoundManagerEvent.emit (SoundManagerType.TURMEL04);
			break;
		case 5:
			SoundManagerEvent.emit (SoundManagerType.TURMEL05);
			break;
		case 6:
			SoundManagerEvent.emit (SoundManagerType.TURMEL06);
			break;
		case 7:
			SoundManagerEvent.emit (SoundManagerType.TURMEL07);
			break;
		case 8:
			SoundManagerEvent.emit (SoundManagerType.TURMEL08);
			break;
		case 9:
			SoundManagerEvent.emit (SoundManagerType.TURMEL09);
			break;
		case 10:
			SoundManagerEvent.emit (SoundManagerType.TURMEL10);
			break;
		}
	}



/*	IEnumerator WaitImage2 ()
	{
		yield return new WaitForSeconds (m_WaitBetween)
			
			ScriptTextSystem.instance.Display1 (0, 1f); //Ah! Vous entendez ça?
		
		yield return new WaitForSeconds (m_WaitBetween)
			
			SoundManagerEvent.emit (SoundManagerType.TURMEL00);
		
		//StartCoroutine (Attente());// La coroutine n'arrete pas la progression du programme, elle se fait en parallèle. 
		
		yield return new WaitForSeconds (m_WaitBetween)
			
			ScriptTextSystem.instance.Display1 (1, m_WaitBetween); //C’est la cloche de Turmel, c’est joli, non ? Son histoire est des plus étonnantes : Il y a bien longtemps, en 1816 exactement, un vol fut commis à Metz. 
		
		yield return new WaitForSeconds (m_WaitBetween)
			
			ScriptTextSystem.instance.Display2 (0,m_WaitBetween*2); //Oooooh
		
		yield return new WaitForSeconds (m_WaitBetween)
			
			ScriptTextSystem.instance.Erase2 (m_WaitBetween*3);// Erase Oooooh
		
		yield return new WaitForSeconds (m_WaitBetween)
			
			ScriptTextSystem.instance.Display1 (2, m_WaitBetween*3);//Ce vol entrera dans l'histoire de Metz. En 1816, une bourgeoise de Metz s'aperçut que ses bijoux lui avaient été dérobés. Furieuse, elle décida de mener son enquête.
		
		yield return new WaitForSeconds (m_WaitBetween)
			
			ScriptImageSystem.instance.ImageDisplay (1, m_WaitBetween*3 + m_WaitSupImage);
		
		yield return new WaitForSeconds (m_WaitBetween)
			
			ScriptTextSystem.instance.Display1 (3, m_WaitBetween*4);//Elle finit par accuser sa femme de chambre. La malheureuse servante de réussit pas à prouver son innocence. Toute la ville de Metz l’accusa à son tour, et la pauvre bonne fut pendue.
		
		yield return new WaitForSeconds (m_WaitBetween)
			
			ScriptTextSystem.instance.Display1 (4, m_WaitBetween*5);//Plus tard, la fille du maire, Mademoiselle de	Turmel, décida d’aller se promener.
		
		ScriptTextSystem.instance.Display1 (5, m_WaitBetween*6);//Durant son excursion, elle remarqua une pie qui transportait dans son bec ce qui semblait être un collier.
		
		ScriptTextSystem.instance.Display1 (6, m_WaitBetween*7);//Elle décida de suivre l’oiseau et, à sa grande surprise, découvrit que son nid était rempli de bijoux, dont ceux de la bourgeoise
		
		ScriptImageSystem.instance.ImageDisplay (2, m_WaitBetween*7 + m_WaitSupImage);
		
		ScriptTextSystem.instance.Display2 (1,m_WaitBetween*8);// Ohlalaaaaaaa
		
		ScriptTextSystem.instance.Erase2 (m_WaitBetween*9);// Erase Ohlalaaaaaaa
		
		ScriptTextSystem.instance.Display1 (7, m_WaitBetween*9);//Les pies sont bien connues pour voler tout ce qui brille. Quoi qu’il en soit, Mademoiselle de Turmel s’empressa de rapporter sa découverte à la ville.
		
		ScriptTextSystem.instance.Display1 (8, m_WaitBetween*10);//Les habitants de Metz eurent honte d’avoir accusé la servante à tort.
		
		ScriptTextSystem.instance.Display1 (9, m_WaitBetween*11);//Et pour que celle-ci puisse entendre leurs excuses depuis le ciel, Mademoiselle de Turmel fit placer une cloche dans la plus haute tour de la cathédrale.
		
		ScriptImageSystem.instance.ImageDisplay (3, m_WaitBetween*11 + m_WaitSupImage);
		
		ScriptTextSystem.instance.Display1 (10, m_WaitBetween*12);//Depuis, la cloche qui porte désormais le nom de Turmel, sonne tous les jours à 21h54. Tendez l’oreille, ce sont des pardons qui montent au ciel…
		
	}*/

	/*while (m_NumberSequence<11) 
	{
		yield return new WaitForSeconds (m_Waiting);
		Debug.Log ("milieu");
		ScriptTextSystem.instance.Display1 (m_NumberSequence); //Ah! Vous entendez ça?
		SoundPlay(m_NumberSequence);
		StartCoroutine(MishSpeak(m_NumberSequence));
		
		if (m_NumberSequence == 1 || m_NumberSequence ==6)
		{
			m_WaitFactor = 2;
			
		}
		
		
		
		
		
		m_WaitFactor=1;			
		
		m_NumberSequence ++;
		Debug.Log (m_NumberSequence);
		Debug.Log ("fin");
	}*/

}
