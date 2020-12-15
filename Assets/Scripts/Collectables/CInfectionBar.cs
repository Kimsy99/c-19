using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInfectionBar : Collectables
{
  [SerializeField] private ParticleSystem recoverEffect;

  protected override void Pick()
  {
    ReduceInfect();
  }

  protected override void PlayEffects()
  {
    Instantiate(recoverEffect, transform.position, Quaternion.identity);
  }

  public void ReduceInfect()
  {
    if (character != null)
    {
      character.GetComponent<KenHealth>().reduceInfection();
    }
  }
}
