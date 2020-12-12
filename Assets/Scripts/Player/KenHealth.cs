using System.Collections;
using UnityEngine;

public class KenHealth : Health
{
	[Header("Infection")]
	[SerializeField] private float maxInfection = 100;

	[Header("Settings")]
	[SerializeField] private bool isInfecting;
	[SerializeField] private bool isHurting = false;

	private GameObject heartIcon1;
	private GameObject heartIcon2;
	private GameObject heartIcon3;
	private Animator animator;
	private readonly int isDeadParameter = Animator.StringToHash("IsDead");
	private Ken ken;
	private GameObject weaponHolder;

	private float infection = 0;
	private int lives = 3;
	private float invulnerabilityTimer = 0;

	protected override void Awake()
	{
		base.Awake();
		heartIcon1 = GameObject.Find("HeartIcon1");
		heartIcon2 = GameObject.Find("HeartIcon2");
		heartIcon3 = GameObject.Find("HeartIcon3");
		animator = GetComponent<Animator>();
		ken = GetComponent<Ken>();
		weaponHolder = GameObject.Find("WeaponHolder");
		UIManager.Instance.SetStats(Hp, maxHp, infection, maxInfection);
	}
	
	void Update()
	{
		invulnerabilityTimer = Mathf.Max(invulnerabilityTimer - Time.deltaTime, 0);
		isInvulnerable = invulnerabilityTimer > 0;

		if (IsDead())
		{
			if (Input.GetKeyDown(KeyCode.R))
				Revive();
			return;
		}

		if (Infection >= maxInfection / 2)
			Damage(0.001F);
		if (!isInvulnerable && Input.GetKeyDown(KeyCode.L))
		{
			if (Damage(1))
			{
				ken.flash.Flash();
				invulnerabilityTimer = 0.1F;
			}
		}
		if (Input.GetKeyDown(KeyCode.K) || isInfecting)
			Infect(1);
	}

	public override float Hp
	{
		get => base.Hp;
		set
		{
			base.Hp = value;
			UIManager.Instance.SetStats(value, maxHp, infection, maxInfection);
		}
	}

	public float Infection
	{
		get => infection;
		set
		{
			infection = Mathf.Clamp(value, 0, maxInfection);
			UIManager.Instance.SetStats(Hp, maxHp, infection, maxInfection);
		}
	}

	public void Infect(float infection)
	{
		Infection += infection;
	}
	
	public override void Die()
	{
		ken.flash.Flash();
		ken.movement.speedMultiplier = 0;
		weaponHolder.SetActive(false);
		animator.SetBool(isDeadParameter, true);
	}

	// Revive this game object    
	public void Revive()
	{
		weaponHolder.SetActive(true);
		animator.SetBool(isDeadParameter, false);
		ken.movement.speedMultiplier = 1;
		Hp = maxHp;
		Infection = 0;
		lives--;

		ken.shooting.cooldown = 0;

		if (lives == 2)
			heartIcon1.SetActive(false);
		else if (lives == 1)
			heartIcon2.SetActive(false);
		else
			heartIcon3.SetActive(false);
	}
}
