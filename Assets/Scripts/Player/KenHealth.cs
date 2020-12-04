using UnityEngine;

public class KenHealth : MonoBehaviour
{
	[Header("Health")]
	[SerializeField] private float initialHealth = 100;
	[SerializeField] private float maxHealth = 100;
	private int lives = 3;

	[Header("Infection")]
	[SerializeField] private float initialInfection = 0;
	[SerializeField] private float maxInfection = 100;

	[Header("Settings")]
	[SerializeField] private bool isInfecting;
	[SerializeField] private bool isHurting = false;
	
	private GameObject heartIcon1;
	private GameObject heartIcon2;
	private GameObject heartIcon3;

	private KenFlash kenFlash;
	private Character character;
	private Collider2D collider2D;
	private SpriteRenderer spriteRenderer;

	// Controls the current health of the object    
	public float Health { get; set; }

	// Returns the current health of this character
	public float Infection { get; set; }

	void Awake()
	{
		kenFlash = GetComponent<KenFlash>();
		character = GetComponent<Character>();
		collider2D = GetComponent<Collider2D>();
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();

		Health = initialHealth;
		Infection = initialInfection;
		UIManager.Instance.SetStatus(Health, maxHealth, Infection, maxInfection);
	}
	
	private void Update()
	{
		if (Infection >= (maxInfection / 2))
			Damage(1);
		if (Input.GetKeyDown(KeyCode.L))
		{
			Damage(1);
			kenFlash.Flash();
		}
		//if (Input.GetKeyDown(KeyCode.K) || isinfecting)
		//	BeInfected(1);
	}
	
	// Take the amount of damage we pass in parameters
	public void Damage(int damage)
	{
		Health -= damage;
		Health = Mathf.Clamp(Health, 0, maxHealth);
		UIManager.Instance.SetStatus(Health, maxHealth, Infection, maxInfection);

		//if (Health <= 0)
		//	Die();
	}

	//// Kills the game object
	//public void BeInfected(int infect)
	//{
	//	if (Infection >= maxInfection)
	//		return;

	//	Infection += infect;
	//	UIManager.Instance.SetStatus(Health, maxHealth, initialInfection, maxInfection);
	//}

	//// infects the game object

	//private void Die()
	//{
	//	if (character != null)
	//	{
	//		collider2D.enabled = false;
	//		spriteRenderer.enabled = false;

	//		character.enabled = false;
	//	}

	//	if (destroyObject)
	//		DestroyObject();
	//	if (lives == 1)
	//	{
	//		Health3.SetActive(false);
	//		gameObject.SetActive(false);
	//	}
	//}

	//// Revive this game object    
	//public void Revive()
	//{
	//	gameObject.SetActive(true);
	//	if (lives == 2)
	//	{
	//		if (character != null)
	//		{
	//			print("life_num  == 2  ccccc");
	//			collider2D.enabled = true;
	//			spriteRenderer.enabled = true;

	//			character.enabled = true;
	//		}

	//		Health2.SetActive(false);

	//		Health = initialHealth;
	//		Infection = initialInfection;

	//		UIManager.Instance.UpdateHealth(Health, maxHealth, Infection, initialInfection, maxInfection);
	//		lives = lives - 1;
	//	}

	//	if (lives == 3)
	//	{
	//		if (character != null)
	//		{
	//			collider2D.enabled = true;
	//			spriteRenderer.enabled = true;

	//			character.enabled = true;
	//		}

	//		Health1.SetActive(false);

	//		Health = initialHealth;
	//		Infection = initialInfection;

	//		UIManager.Instance.UpdateHealth(Health, maxHealth, Infection, initialInfection, maxInfection);
	//		lives = lives - 1;
	//	}
	//}

	//// If destroyObject is selected, we destroy this game object
	//private void DestroyObject()
	//{
	//	gameObject.SetActive(false);
	//}
}



