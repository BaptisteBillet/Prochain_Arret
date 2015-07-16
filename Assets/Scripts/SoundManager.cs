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
		SoundManagerEvent.onEvent += Play;
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
				Source[2].clip = Voice[0];
				Source[2].Play();
				break;
			case SoundManagerType.BIENJOUE:
				Source[2].Stop();
				Source[2].clip = Voice[1];
				Source[2].Play();
				break;
			case SoundManagerType.BONBOULOT:
				Source[2].Stop();
				Source[2].clip = Voice[2];
				Source[2].Play();
				break;
			case SoundManagerType.BRAVO:
				Source[2].Stop();
				Source[2].clip = Voice[3];
				Source[2].Play();
				break;
			case SoundManagerType.EXCELLENT:
				Source[2].Stop();
				Source[2].clip = Voice[4];
				Source[2].Play();
				break;
			case SoundManagerType.SUPER:
				Source[2].Stop();
				Source[2].clip = Voice[5];
				Source[2].Play();
				break;
			case SoundManagerType.AIEAIEAIE1:
				Source[2].Stop();
				Source[2].clip = Voice[6];
				Source[2].Play();
				break;
			case SoundManagerType.AIEAIEAIE2:
				Source[2].Stop();
				Source[2].clip = Voice[7];
				Source[2].Play();
				break;
			case SoundManagerType.AIEAIEAIE3:
				Source[2].Stop();
				Source[2].clip = Voice[8];
				Source[2].Play();
				break;
			case SoundManagerType.CENESTPASCA:
				Source[2].Stop();
				Source[2].clip = Voice[9];
				Source[2].Play();
				break;
			case SoundManagerType.NONNONNON1:
				Source[2].Stop();
				Source[2].clip = Voice[10];
				Source[2].Play();
				break;
			case SoundManagerType.NONNONNON2:
				Source[2].Stop();
				Source[2].clip = Voice[11];
				Source[2].Play();
				break;
			case SoundManagerType.PERDU:
				Source[2].Stop();
				Source[2].clip = Voice[12];
				Source[2].Play();
				break;
			case SoundManagerType.PRESQUE:
				Source[2].Stop();
				Source[2].clip = Voice[13];
				Source[2].Play();
				break;
			case SoundManagerType.TUFERASMIEUX:
				Source[2].Stop();
				Source[2].clip = Voice[14];
				Source[2].Play();
				break;
			case SoundManagerType.RANDOMPOSITIVE:
				Source[2].Stop();
				Source[2].clip = Voice[Random.Range(0, 6)];
				Source[2].Play();
				break;
			case SoundManagerType.RANDOMNEGATIVE:
				Source[2].Stop();
				Source[2].clip = Voice[Random.Range(6, 14)];
				Source[2].Play();
				break;

			case SoundManagerType.TURMEL00:
				Source[2].Stop();
				Source[2].clip = Voice[15];
				Source[2].Play();
			Debug.Log("Turmel 00");
				break;

			case SoundManagerType.TURMEL01:
				Source[2].Stop();
				Source[2].clip = Voice[16];
				Source[2].Play();
				break;

			case SoundManagerType.TURMEL02:
				Source[2].Stop();
				Source[2].clip = Voice[17];
				Source[2].Play();
				break;

			case SoundManagerType.TURMEL03:
				Source[2].Stop();
				Source[2].clip = Voice[18];
				Source[2].Play();
				break;

			case SoundManagerType.TURMEL04:
				Source[2].Stop();
				Source[2].clip = Voice[19];
				Source[2].Play();
				break;

			case SoundManagerType.TURMEL05:
				Source[2].Stop();
				Source[2].clip = Voice[20];
				Source[2].Play();
				break;

			case SoundManagerType.TURMEL06:
				Source[2].Stop();
				Source[2].clip = Voice[21];
				Source[2].Play();
				break;

			case SoundManagerType.TURMEL07:
				Source[2].Stop();
				Source[2].clip = Voice[22];
				Source[2].Play();
				break;

			case SoundManagerType.TURMEL08:
				Source[2].Stop();
				Source[2].clip = Voice[23];
				Source[2].Play();
				break;

			case SoundManagerType.TURMEL09:
				Source[2].Stop();
				Source[2].clip = Voice[24];
				Source[2].Play();
				break;

			case SoundManagerType.TURMEL10:
				Source[2].Stop();
				Source[2].clip = Voice[25];
				Source[2].Play();
				break;


		}
	}

	

}
