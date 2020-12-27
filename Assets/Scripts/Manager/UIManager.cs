using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
	private Image healthBar;
	private Image healthBarInfected;
	private Image healthBarBackground;
	private Image infectionBar;
	public GameObject bossBarContainer;
	[HideInInspector] public Image bossBar;
	[HideInInspector] public Image bossBarBackground;
	[SerializeField] private float fillAmountChangeRate = 1;

	private float playerHealth = 5F;
	private float playerMaxHealth = 10F;
	private float playerInfection;
	private float playerMaxInfection;

	void Start()
	{
		Transform statsBarContainer = GameObject.Find("StatsBarContainer").transform;
		healthBar = statsBarContainer.Find("HealthBarContainer").Find("HealthBar").GetComponent<Image>();
		healthBarInfected = statsBarContainer.Find("HealthBarContainer").Find("HealthBarInfected").GetComponent<Image>();
		healthBarBackground = statsBarContainer.Find("HealthBarContainer").Find("HealthBarBackground").GetComponent<Image>();
		infectionBar = statsBarContainer.Find("InfectionBarContainer").Find("InfectionBar").GetComponent<Image>();
		
		bossBar = bossBarContainer.transform.Find("BossBar").GetComponent<Image>();
		bossBarBackground = bossBarContainer.transform.Find("BossBarBackground").GetComponent<Image>();
	}

	void Update()
	{
		UpdateStatBars();
	}

	public void SetStats(float health, float maxHealth, float infection, float maxInfection)
	{
		playerHealth = health;
		playerMaxHealth = maxHealth;
		playerInfection = infection;
		playerMaxInfection = maxInfection;
	}

	private void UpdateStatBars()
	{
		healthBarInfected.fillAmount = playerHealth / playerMaxHealth;
		healthBar.fillAmount = Mathf.Min(Mathf.Lerp(4, 0, playerInfection / playerMaxInfection)/3, healthBarInfected.fillAmount);

		// Dynamically shrink background health bar to match the actual health bar
		if (healthBarBackground.fillAmount - healthBarInfected.fillAmount > fillAmountChangeRate * Time.deltaTime)
			healthBarBackground.fillAmount -= fillAmountChangeRate * Time.deltaTime;
		else
			healthBarBackground.fillAmount = healthBarInfected.fillAmount;

		infectionBar.fillAmount = playerInfection / playerMaxInfection;
	}
}
