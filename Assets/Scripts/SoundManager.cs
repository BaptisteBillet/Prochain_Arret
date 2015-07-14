using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SoundManager : MonoBehaviour {
	#region Members
	[Header("OGG Files")]
	public List<AudioClip> Sound= new List<AudioClip>();

	[Header("OGG Files")]
	public List<AudioClip> Music = new List<AudioClip>();

	[Header("OGG Files")]
	public List<AudioClip> Voice = new List<AudioClip>();

	[Header("Sound Listeners")]
	public List<AudioSource> Source = new List<AudioSource>();


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
				Source[0].Stop();
				Source[0].clip = Sound[0];
				Source[0].Play();
				break;
		}
	}

	

}
