using UnityEngine;

public class KenFlash : Flashable
{
  private ParticleSystem blood;

  protected override void Awake()
  {
    base.Awake();
    blood = GetComponentInChildren<ParticleSystem>();
  }

  public override void Flash()
  {
    base.Flash();
    blood.Play();
    // SoundManager.Instance.Play(SoundManager.Sound.KenHurt);
  }
}
