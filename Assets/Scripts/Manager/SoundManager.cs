using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Central place to hold and play all the sounds.
/// </summary>
public class SoundManager : Singleton<SoundManager>
{
	[SerializeField] private SoundDefinition[] soundDefinitions;
	private readonly Dictionary<Sound, AudioClip> soundDictionary = new Dictionary<Sound, AudioClip>();

	private AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		foreach (SoundDefinition definition in soundDefinitions)
			soundDictionary.Add(definition.sound, definition.audioClip);
	}

	/// <summary>
	/// Plays a sound.
	/// </summary>
	/// <param name="sound">the sound</param>
	public void Play(Sound sound)
	{
		audioSource.PlayOneShot(GetAudioClip(sound));
	}

	private AudioClip GetAudioClip(Sound sound)
	{
		return soundDictionary[sound];
	}

	/// <summary>
	/// Defines a sound definition that maps a Sound enum to its actual AudioClip. You can edit this in the
	/// Unity editor.
	/// </summary>
	[System.Serializable]
	public class SoundDefinition
	{
		public Sound sound;
		public AudioClip audioClip;
	}
	
	public enum Sound
	{
		KenHurt,
		KenSelect,
		EnemyHurt,
		PistolShoot,
		PlasmaGunShoot
	}
}
