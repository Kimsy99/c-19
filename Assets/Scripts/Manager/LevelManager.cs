using System;
using System.Collections;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
  private CameraController cameraController;

  private Ken ken;
  private HeldWeapon heldWeapon;
  private Transform bulletSpawner;
  [SerializeField] private WeaponSettings firstWeaponSettings = null;
  [SerializeField] private WeaponSettings secondWeaponSettings = null;
  [SerializeField] private WeaponSettings thirdWeaponSettings = null;

  [SerializeField] private GameObject flashLight = null;

  public Action OnBossBarPostInit;

  private AudioSource levelTheme;

  public bool IsBossIntro { get; private set; }
  public bool IsBossReady { get; private set; }

  protected override void Awake()
  {
    base.Awake();
    cameraController = Camera.main.GetComponent<CameraController>();

    ken = GameObject.Find("Ken").GetComponent<Ken>();
    heldWeapon = ken.GetComponentInChildren<HeldWeapon>();
    bulletSpawner = ken.transform.Find("WeaponHolder").Find("BulletSpawner");
  }

  void Start()
  {
    Weapon firstWeapon = new Weapon(firstWeaponSettings);
    InventoryManager.Instance.SetWeapon(0, firstWeapon);
    InventoryManager.Instance.SetWeapon(1, new Weapon(secondWeaponSettings));
    InventoryManager.Instance.SetWeapon(2, new Weapon(thirdWeaponSettings));
    heldWeapon.SetHeldWeapon(firstWeapon);

    // levelTheme = AudioManager.Instance.Play(AudioEnum.Level4Theme);
  }

  void Update()
  {
    if (levelTheme == null)
      return;
    if (ken.health.IsDead)
    {
      if (levelTheme.pitch > 0)
        levelTheme.pitch -= 0.4F * Time.deltaTime;
    }
    else
      levelTheme.pitch = 1;
  }

  public void SetFlashLightEnabled(bool isEnabled)
  {
    Instantiate(flashLight, bulletSpawner);
  }

  public void IntroBoss(GameObject boss)
  {
    levelTheme = AudioManager.Instance.Play(AudioEnum.BossTheme);
    UIManager.Instance.bossBarContainer.SetActive(true); // Show boss bar
    IsBossIntro = true;
    cameraController.secondaryTarget = boss.transform; // Switch target to boss
    cameraController.primaryTargetWeightage = 0;
  }

  public void InitBossHealthBar()
  {
    AudioManager.Instance.Play(AudioEnum.Regenerate);
    StartCoroutine(InitBossHealth());
  }

  private IEnumerator InitBossHealth()
  {
    float timeElapsed = 0;
    while (true)
    {
      timeElapsed += Time.deltaTime;
      UIManager.Instance.bossBar.fillAmount = Mathf.Min(timeElapsed / 3.4F, 1);
      if (UIManager.Instance.bossBar.fillAmount == 1)
        break;
      yield return new WaitForEndOfFrame();
    }
    IsBossIntro = false;
    IsBossReady = true;

    cameraController.primaryTargetWeightage = 1;
    cameraController.camSize = 6;

    OnBossBarPostInit?.Invoke();
  }

  public void ExitBossMode()
  {
    UIManager.Instance.bossBarContainer.SetActive(false);

    cameraController.secondaryTarget = null;
    cameraController.primaryTargetWeightage = 5;
    cameraController.camSize = 4;
  }

  public void GameOver()
  {
    cameraController.secondaryTarget = null;
    cameraController.secondaryTargetWeightage = 0;
    cameraController.camSize = 3;
  }
}