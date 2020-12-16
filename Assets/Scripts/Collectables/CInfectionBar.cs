using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInfectionBar : Collectables
{
	[SerializeField] private ParticleSystem recoverEffect = null;

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
		ken.health.reduceInfection();
	}
}
