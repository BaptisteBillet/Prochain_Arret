using UnityEngine;
using System.Collections;

public class ScriptVisiteManager : MonoBehaviour {

	public float m_WaitDepart;
	public float m_WaitBetween;
	public float m_WaitSupImage;



	void Start () 
	{
		ScriptTextSystem.instance.Display1 (0, 1f); //Ah! Vous entendez ça?
		//StartCoroutine (Attente());// La coroutine n'arrete pas la progression du programme, elle se fait en parallèle. 

		ScriptTextSystem.instance.Display1 (1, m_WaitBetween); //C’est la cloche de Turmel, c’est joli, non ? Son histoire est des plus étonnantes : Il y a bien longtemps, en 1816 exactement, un vol fut commis à Metz. 

		ScriptTextSystem.instance.Display2 (0,m_WaitBetween*2); //Oooooh

		ScriptTextSystem.instance.Erase2 (m_WaitBetween*3);// Erase Oooooh

		ScriptTextSystem.instance.Display1 (2, m_WaitBetween*3);//Ce vol entrera dans l'histoire de Metz. En 1816, une bourgeoise de Metz s'aperçut que ses bijoux lui avaient été dérobés. Furieuse, elle décida de mener son enquête.

		ScriptImageSystem.instance.ImageDisplay (1, m_WaitBetween*3 + m_WaitSupImage);

		ScriptTextSystem.instance.Display1 (3, m_WaitBetween*4);//Elle finit par accuser sa femme de chambre. La malheureuse servante de réussit pas à prouver son innocence. Toute la ville de Metz l’accusa à son tour, et la pauvre bonne fut pendue.

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
	}
	



}
