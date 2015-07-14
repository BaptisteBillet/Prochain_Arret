using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	#region Members
	public AudioClip Damage ;


	public AudioSource camera;


	#endregion

	// Use this for initialization
	void Start()
	{
		/*
		SoundManagerEvent.onEvent += Effect;
		camera.Stop();
		camera.clip = Oreebleue_A;
		camera.Play();
		camera_ui.Stop();
		camera_ui.clip = Oreebleue_T;
		camera_ui.Play();
		*/

	}

	void OnDestroy()
	{
		SoundManagerEvent.onEvent -= Play;
	}

	void Play(SoundManagerType emt)
	{
		switch (emt)
		{
			case SoundManagerType.SOUND1:
				camera.Stop();
				camera.clip = Damage;
				camera.Play();
				break;
		}
	}

	

}
