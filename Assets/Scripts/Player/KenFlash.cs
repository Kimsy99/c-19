using UnityEngine;

public class KenFlash : Flashable
{
	private ParticleSystem blood;
	private AudioSource hurt;

	protected override void Start()
	{
		base.Start();
		blood = GetComponentInChildren<ParticleSystem>();
		hurt = GetComponent<AudioSource>();
	}

	public override void Flash()
	{
		base.Flash();
		blood.Play();
		hurt.Play();
	}
}
