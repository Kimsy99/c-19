using System;
using System.Collections;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
	[HideInInspector] public CameraController cameraController;
	public int levelNumber;
	public AudioEnum levelThemeEnum;
	private AudioSource levelTheme;
	private GameObject boss;
	public Action OnBossBarPostInit;

	private Ken ken;
	private HeldWeapon heldWeapon;

	private bool canPlayerMove = true;

	public bool CanPlayerMove
	{
		get => canPlayerMove && !ken.health.IsDead;
		set
		{
			canPlayerMove = value;
		}
	}

	public bool IsBossReady { get; set; }

	protected override void Awake()
	{
		base.Awake();
		cameraController = Camera.main.GetComponent<CameraController>();

		ken = FindObjectOfType<Ken>();
		heldWeapon = ken.GetComponentInChildren<HeldWeapon>();
	}

	void Start()
	{
		levelTheme = AudioManager.Instance.Play(levelThemeEnum);

		if (levelNumber == 1)
			return;
		// Load data from previous level
		LevelData levelData = LevelDataManager.Instance.levelData[levelNumber - 2];
		if (levelData != null)
		{
			for (int i = 0; i < 5; i++)
				InventoryManager.Instance.SetWeapon(i, levelData.weapons[i]);
			if (InventoryManager.Instance.GetWeapon(0) != null)
				heldWeapon.SetHeldWeapon(InventoryManager.Instance.GetWeapon(0));
			ken.health.Hp = levelData.health;
			ken.health.Infection = levelData.infection;
		}
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

	public void IntroBoss(GameObject boss)
	{
		this.boss = boss;

		levelTheme = AudioManager.Instance.Play(AudioEnum.BossTheme);
		UIManager.Instance.bossBarContainer.SetActive(true); // Show boss bar
		CanPlayerMove = false;
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
		CanPlayerMove = true;
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

	public void SaveData()
	{
		LevelData data = new LevelData();
		for (int i = 0; i < 5; i++)
			data.weapons[i] = InventoryManager.Instance.GetWeapon(i);
		data.health = ken.health.Hp;
		data.infection = ken.health.Infection;

		LevelDataManager.Instance.levelData[levelNumber - 1] = data;
	}
}
