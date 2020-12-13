using System;
using UnityEngine;

[Serializable]
public class Sound
{
	public SoundEnum soundEnum;
	public AudioClip clip;
	[Range(0, 1)]
	public float volume = 1;
	public float pitch;
	public bool loop;
	[HideInInspector] public AudioSource source;
}
