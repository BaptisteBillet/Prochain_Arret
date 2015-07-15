using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SoundManager : MonoBehaviour {
	#region Members

	[Header("MUSICS")]
	public List<AudioClip> Music = new List<AudioClip>();

	[Header("SOUNDS")]
	public List<AudioClip> Sound= new List<AudioClip>();
	
	[Header("VOICES")]
	public List<AudioClip> Voice = new List<AudioClip>();

	[Header("Sound Listeners")]
	public List<AudioSource> Source = new List<AudioSource>();


	#endregion

	// Use this for initialization
	void Start()
	{
		
	}

	void OnDestroy()
	{
		SoundManagerEvent.onEvent -= Play;
	}

	public void Play(SoundManagerType emt)
	{
		switch (emt)
		{
			case SoundManagerType.ABSOLUMENT:
				Source[2].Stop();
				Source[2].clip = Sound[0];
				Source[2].Play();
				break;
			case SoundManagerType.BIENJOUE:
				Source[2].Stop();
				Source[2].clip = Sound[1];
				Source[2].Play();
				break;
			case SoundManagerType.BONBOULOT:
				Source[2].Stop();
				Source[2].clip = Sound[2];
				Source[2].Play();
				break;
			case SoundManagerType.BRAVO:
				Source[2].Stop();
				Source[2].clip = Sound[3];
				Source[2].Play();
				break;
			case SoundManagerType.EXCELLENT:
				Source[2].Stop();
				Source[2].clip = Sound[4];
				Source[2].Play();
				break;
			case SoundManagerType.SUPER:
				Source[2].Stop();
				Source[2].clip = Sound[5];
				Source[2].Play();
				break;
			case SoundManagerType.AIEAIEAIE1:
				Source[2].Stop();
				Source[2].clip = Sound[6];
				Source[2].Play();
				break;
			case SoundManagerType.AIEAIEAIE2:
				Source[2].Stop();
				Source[2].clip = Sound[7];
				Source[2].Play();
				break;
			case SoundManagerType.AIEAIEAIE3:
				Source[2].Stop();
				Source[2].clip = Sound[8];
				Source[2].Play();
				break;
			case SoundManagerType.CENESTPASCA:
				Source[2].Stop();
				Source[2].clip = Sound[9];
				Source[2].Play();
				break;
			case SoundManagerType.NONNONNON1:
				Source[2].Stop();
				Source[2].clip = Sound[10];
				Source[2].Play();
				break;
			case SoundManagerType.NONNONNON2:
				Source[2].Stop();
				Source[2].clip = Sound[11];
				Source[2].Play();
				break;
			case SoundManagerType.PERDU:
				Source[2].Stop();
				Source[2].clip = Sound[12];
				Source[2].Play();
				break;
			case SoundManagerType.PRESQUE:
				Source[2].Stop();
				Source[2].clip = Sound[13];
				Source[2].Play();
				break;
			case SoundManagerType.TUFERASMIEUX:
				Source[2].Stop();
				Source[2].clip = Sound[14];
				Source[2].Play();
				break;
			case SoundManagerType.RANDOMPOSITIVE:
				Source[2].Stop();
				Source[2].clip = Sound[Random.Range(0,6)];
				Source[2].Play();
				break;
			case SoundManagerType.RANDOMNEGATIVE:
				Source[2].Stop();
				Source[2].clip = Sound[Random.Range(6, 14)];
				Source[2].Play();
				break;
		}
	}

	

}
