﻿using UnityEngine;
using UnityEngine.UI;

public class NPCHealth : Health
{
	private NPC npc;
	private new Collider2D collider2D;
	[SerializeField] private GameObject healthBar;
	protected Animator animator;
	protected readonly int isDeadParameter = Animator.StringToHash("IsDead");

	public Image hpImage;
	public Image hpEffectImage;
	[SerializeField] private float hurtSpeed = 0.005F;

	protected override void Awake()
	{
		base.Awake();
		npc = GetComponent<NPC>();
		collider2D = GetComponent<Collider2D>();
		animator = GetComponent<Animator>();

		OnDie += Die;
	}

	protected override void Update()
	{
		base.Update();
		
		hpImage.fillAmount = Hp / maxHp;
		if (hpEffectImage.fillAmount > hpImage.fillAmount)
			hpEffectImage.fillAmount -= hurtSpeed;
		else
			hpEffectImage.fillAmount = hpImage.fillAmount;
	}

	public virtual bool Damage(float damage, bool shouldFlash = false, float invulnerabilityTime = 0)
	{
		if (!IsDead)
			healthBar.SetActive(true);
		bool damaged = base.Damage(damage, invulnerabilityTime);
		if (!damaged)
			return false;
		if (shouldFlash)
			npc.flashable.Flash();
		return true;
	}

	protected virtual void Die()
	{
		npc.movement.Speed = 0;
		npc.weaponHolder.SetActive(false);
		collider2D.enabled = false;
		healthBar.SetActive(false);
		animator.SetBool(isDeadParameter, true);
		Destroy(gameObject, 10);
		AudioManager.Instance.Play(AudioEnum.EnemyHurt);
	}
}
