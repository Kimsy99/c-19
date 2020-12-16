using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHealthBar : Collectables
{
	[SerializeField] private int healthToAdd = 1;
	[SerializeField] private ParticleSystem healthBonus = null;

	protected override void Pick()
	{
		AddHealth();
	}

	protected override void PlayEffects()
	{
		Instantiate(healthBonus, transform.position, Quaternion.identity);
	}

	public void AddHealth()
	{
		ken.health.Hp += healthToAdd;
	}
}
