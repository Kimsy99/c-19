using System.Collections;
using UnityEngine;

public class KenHealth : Health
{
	[Header("Infection")]
	[SerializeField] private float maxInfection = 100;

	[Header("Settings")]
	[SerializeField] private bool isInfecting = false;
	[SerializeField] private Transform spawnPosition = null;

	private GameObject heartIcon1;
	private GameObject heartIcon2;
	private GameObject heartIcon3;
	private Animator animator;
	private readonly int isDeadParameter = Animator.StringToHash("IsDead");
	private Ken ken;
	private GameObject trigger1;
	private GameObject weaponHolder;

	private float infection = 0;
	private int lives = 3;

	protected override void Awake()
	{
		base.Awake();
		heartIcon1 = GameObject.Find("HeartIcon1");
		heartIcon2 = GameObject.Find("HeartIcon2");
		heartIcon3 = GameObject.Find("HeartIcon3");
		animator = GetComponent<Animator>();
		ken = GetComponent<Ken>();
		weaponHolder = transform.Find("WeaponHolder").gameObject;
		trigger1 = transform.Find("Colliders").Find("Trigger 1").gameObject;
		UIManager.Instance.SetStats(Hp, maxHp, infection, maxInfection);
	}

	void Start()
	{
		ken.health.OnDie += Die;
	}

	protected override void Update()
	{
		base.Update();

		if (IsDead)
		{
			if (Input.GetKeyDown(KeyCode.R))
				Revive();
			return;
		}

		if (Infection >= maxInfection / 2)
			Damage(0.001F);
		if (!IsInvulnerable && Input.GetKeyDown(KeyCode.L))
			Damage(1, true, 0.1F);
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

	public bool Damage(float damage, bool shouldFlash = false, float invulnerabilityTime = 0)
	{
		bool damaged = base.Damage(damage, invulnerabilityTime);
		if (!damaged)
			return false;
		if (shouldFlash)
			ken.flashable.Flash();
		return true;
	}

	public void Infect(float infection, float invulnerabilityTime = 0)
	{
		if (!IsInvulnerable)
			Infection += infection;
		invulnerabilityTimer += invulnerabilityTime;
	}

	private void Die()
	{
		ken.flashable.Flash();
		ken.movement.speedMultiplier = 0;
		weaponHolder.SetActive(false);
		trigger1.SetActive(false);
		animator.SetBool(isDeadParameter, true);

		LevelManager.Instance.GameOver();
	}

	// Revive this game object    
	public void Revive()
	{
		weaponHolder.SetActive(true);
		trigger1.SetActive(true);
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

		if (LevelManager.Instance.IsBossReady)
			LevelManager.Instance.SetBossCameraMode();
		else
		{
			LevelManager.Instance.cameraController.secondaryTargetWeightage = 1;
			LevelManager.Instance.cameraController.camSize = 4;
		}

		if (!LevelManager.Instance.IsBossReady)
			transform.position = spawnPosition.position;
	}
}
