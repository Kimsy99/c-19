﻿using UnityEngine;

public class NPCHurtOnCollide : MonoBehaviour
{
	private Ken ken;
	private bool isHurtingKen;
	[SerializeField] private float collisionDamage = 0.5F;
	[SerializeField] private float infectionRate = 0.15F;

	void Awake()
	{
		ken = FindObjectOfType<Ken>();
	}

	void Update()
	{
		if (isHurtingKen)
		{
			ken.movement.RecoilFrom(transform);
			if (ken.health.Damage(collisionDamage, true, 0.25F))
				ken.health.Infect(infectionRate);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			isHurtingKen = true;
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
			isHurtingKen = false;
	}
}
