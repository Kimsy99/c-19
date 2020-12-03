using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
	[Header("Settings")]
	[SerializeField] private Image healthBar;
	[SerializeField] private Image infectionBar;
	[SerializeField] private TextMeshProUGUI currentHealthTMP;
	[SerializeField] private TextMeshProUGUI currentInfectionTMP;

	private float playerCurrentHealth;
	private float playerMaxHealth;
	private float playerInitialInfection;
	private float playerCurrentInfection;
	private float playerMaxInfection;

	private void Update()
	{
		InternalUpdate();
	}

	public void UpdateHealth(float currentHealth, float maxHealth, float currentInfection, float initialInfection, float maxInfection)
	{
		playerCurrentHealth = currentHealth;
		playerMaxHealth = maxHealth;
		playerCurrentInfection = currentInfection;
		playerInitialInfection = initialInfection;
		playerMaxInfection = maxInfection;
	}

	private void InternalUpdate()
	{
		healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerCurrentHealth / playerMaxHealth, 10f * Time.deltaTime);
		currentHealthTMP.text = playerCurrentHealth.ToString() + "/" + playerMaxHealth.ToString();

		infectionBar.fillAmount = Mathf.Lerp(infectionBar.fillAmount, playerCurrentInfection / playerMaxInfection, 10f * Time.deltaTime);
		currentInfectionTMP.text = playerCurrentInfection.ToString() + "/" + playerMaxInfection.ToString();
	}
}
