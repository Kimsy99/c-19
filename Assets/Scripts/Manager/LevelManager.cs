using System;
using System.Collections;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
	[HideInInspector] public CameraController cameraController;

	private Ken ken;
	private HeldWeapon heldWeapon;
	private Transform bulletSpawner;
	[SerializeField] private WeaponSettings firstWeaponSettings = null;
	[SerializeField] private WeaponSettings secondWeaponSettings = null;
	[SerializeField] private WeaponSettings thirdWeaponSettings = null;

	[SerializeField] private GameObject flashLight = null;
	[SerializeField] private bool isFlashLightEnabled = false;

	public Action OnBossBarPostInit;

	public AudioEnum levelThemeEnum;
	private AudioSource levelTheme;
	private GameObject boss;

	public bool IsBossIntro { get; private set; }
	public bool IsBossReady { get; set; }

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

		levelTheme = AudioManager.Instance.Play(levelThemeEnum);

		if (isFlashLightEnabled)
			EnableFlashLight();
	}

	void Update()
	{
		if (ken.health.IsDead)
		{
			if (levelTheme.pitch > 0)
				levelTheme.pitch -= 0.4F * Time.deltaTime;
		}
		else
			levelTheme.pitch = 1;

		if (Input.GetKeyDown(KeyCode.Escape))
			SceneLoader.Instance.LoadScene("MainMenu");
	}

	public void EnableFlashLight()
	{
		Instantiate(flashLight, bulletSpawner);
	}

	public void IntroBoss(GameObject boss)
	{
		this.boss = boss;

		levelTheme = AudioManager.Instance.Play(AudioEnum.BossTheme);
		UIManager.Instance.bossBarContainer.SetActive(true); // Show boss bar
		IsBossIntro = true;
		cameraController.secondaryTarget = boss.transform; // Switch target to boss
		cameraController.primaryTargetWeightage = 0;
	}

	public void SetBossCameraMode()
	{
		cameraController.primaryTargetWeightage = 1;
		cameraController.secondaryTarget = boss.transform;
		cameraController.secondaryTargetWeightage = 1;
		cameraController.camSize = 5.5F;
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

		SetBossCameraMode();

		OnBossBarPostInit?.Invoke();
	}

	public void ExitBossMode()
	{
		UIManager.Instance.bossBarContainer.SetActive(false);

		cameraController.secondaryTarget = null;
		cameraController.secondaryTargetWeightage = 1;
		cameraController.primaryTargetWeightage = 5;
		cameraController.camSize = 4;

		boss = null;
	}

	public void GameOver()
	{
		cameraController.secondaryTarget = null;
		cameraController.secondaryTargetWeightage = 0;
		cameraController.camSize = 3;
	}
}
