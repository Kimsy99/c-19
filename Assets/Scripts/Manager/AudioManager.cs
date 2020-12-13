using System;
using UnityEngine;

/// <summary>
/// Central place to hold and play all the sounds.<br/>
/// 
/// To add your own sound, go to SoundEnum to add your own sound enum, then in the inspector,
/// inspect the AudioManager game object and add your sound entry.
/// </summary>
public class AudioManager : Singleton<AudioManager>
{
	public Sound[] sounds;

	protected override void Awake()
	{
		foreach (Sound sound in sounds)
		{
			sound.source = gameObject.AddComponent<AudioSource>();
			sound.source.clip = sound.clip;
			sound.source.volume = sound.volume;
			sound.source.pitch = sound.pitch;
			sound.source.loop = sound.loop;
		}
	}

	/// <summary>
	/// Plays a sound.
	/// </summary>
	/// <param name="soundEnum">the sound</param>
	public void Play(SoundEnum soundEnum)
	{
		Sound theSound = GetSound(soundEnum);
		theSound?.source.Play();
	}

	/// <summary>
	/// Stops a sound.
	/// </summary>
	/// <param name="soundEnum">the sound</param>
	public void Stop(SoundEnum soundEnum)
	{
		Sound theSound = GetSound(soundEnum);
		theSound?.source.Stop();
	}

	private Sound GetSound(SoundEnum soundEnum)
	{
		Sound theSound = Array.Find(sounds, sound => sound.soundEnum == soundEnum);
		if (theSound == null)
			Debug.LogError("Sound with sound enum " + soundEnum + " does not exist!");
		return theSound;
	}
}
