using UnityEngine;

public class KenHealth : KenFlash
{
	[Header("Health")]
	[SerializeField] private float initialHealth = 100;
	[SerializeField] private float maxHealth = 100;

	[Header("Infection")]
	[SerializeField] private float initialInfection = 0;
	[SerializeField] private float maxInfection = 100;

	[Header("Settings")]
	[SerializeField] private bool isInvulnerable;
	[SerializeField] private bool isInfecting;
	[SerializeField] private bool isHurting = false;
	[SerializeField] private Sprite ken, kenDead;

	private GameObject heartIcon1;
	private GameObject heartIcon2;
	private GameObject heartIcon3;
	private Animator animator;
	private KenMovement kenMovement;

	private float health;
	private float infection;
	private int lives = 3;

	void Awake()
	{
		heartIcon1 = GameObject.Find("HeartIcon1");
		heartIcon2 = GameObject.Find("HeartIcon2");
		heartIcon3 = GameObject.Find("HeartIcon3");
		animator = GetComponent<Animator>();
		kenMovement = GetComponent<KenMovement>();

		Health = initialHealth;
		Infection = initialInfection;
	}
	
	private void Update()
	{
		if (Health == 0)
		{
			if (Input.GetKeyDown(KeyCode.R))
				Revive();
			return;
		}

		if (Infection >= maxInfection / 2)
			Damage(0.001F);
		if (!isInvulnerable && Input.GetKeyDown(KeyCode.L))
		{
			Damage(1);
			Flash();
		}
		if (Input.GetKeyDown(KeyCode.K) || isInfecting)
			Infect(1);
	}

	public float Health
	{
		get => health;
		set
		{
			health = Mathf.Clamp(value, 0, maxHealth);
			UIManager.Instance.SetStats(health, maxHealth, infection, maxInfection);
		}
	}

	public float Infection
	{
		get => infection;
		set
		{
			infection = Mathf.Clamp(value, 0, maxInfection);
			UIManager.Instance.SetStats(health, maxHealth, infection, maxInfection);
		}
	}
	
	// Take the amount of damage we pass in parameters
	public void Damage(float damage)
	{
		Health -= damage;
		if (Health == 0)
			Die();
	}

	public void Infect(float infection)
	{
		Infection += infection;
	}
	
	private void Die()
	{
		Flash();
		animator.enabled = false;
		kenMovement.speedMultiplier = 0;
		spriteRenderer.sprite = kenDead;
	}

	// Revive this game object    
	public void Revive()
	{
		animator.enabled = true;
		kenMovement.speedMultiplier = 1;
		Health = initialHealth;
		Infection = initialInfection;
		lives--;

		if (lives == 2)
			heartIcon1.SetActive(false);
		else if (lives == 1)
			heartIcon2.SetActive(false);
		else
			heartIcon3.SetActive(false);
	}
}
