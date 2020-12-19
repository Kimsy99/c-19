using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
  private Image healthBar;
  private Image healthBarBackground;
  private Image infectionBar;
  [SerializeField] private float fillAmountChangeRate = 1;
  //[SerializeField] private TextMeshProUGUI currentHealthTMP;
  //[SerializeField] private TextMeshProUGUI currentInfectionTMP;

  private float playerHealth = 5F;
  private float playerMaxHealth = 10F;
  private float playerInfection;
  private float playerMaxInfection;

  void Start()
  {
    healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
    healthBarBackground = GameObject.Find("HealthBarBackground").GetComponent<Image>();
    infectionBar = GameObject.Find("InfectionBar").GetComponent<Image>();
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
    healthBar.fillAmount = playerHealth / playerMaxHealth;

    // Dynamically shrink background health bar to match the actual health bar
    if (healthBarBackground.fillAmount - healthBar.fillAmount > fillAmountChangeRate * Time.deltaTime)
      healthBarBackground.fillAmount -= fillAmountChangeRate * Time.deltaTime;
    else
      healthBarBackground.fillAmount = healthBar.fillAmount;
    //currentHealthTMP.text = playerCurrentHealth.ToString() + "/" + playerMaxHealth.ToString();

    infectionBar.fillAmount = playerInfection / playerMaxInfection;
    //currentInfectionTMP.text = playerCurrentInfection.ToString() + "/" + playerMaxInfection.ToString();
  }
}
