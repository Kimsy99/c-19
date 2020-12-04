using UnityEngine;

public class KenFlash : Flashable
{
	private ParticleSystem blood;

	protected override void Start()
	{
		base.Start();
		blood = GetComponentInChildren<ParticleSystem>();
	}

	public override void Flash()
	{
		base.Flash();
		blood.Play();
		SoundManager.Instance.Play(SoundManager.Sound.KenHurt);
	}
}
