using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Boss4Trigger : MonoBehaviour
{
	[SerializeField] private SteelDoor[] steelDoorsToLock = null;
	[SerializeField] private Terminal boss = null;
	[SerializeField] private GameObject bossBarContainer = null;

	private Animator animator;
	private CameraController cameraController;
	private new BoxCollider2D collider2D;
	private Ken ken;
	private Image healthBar;

	void Awake()
	{
		animator = GetComponent<Animator>();
		cameraController = Camera.main.GetComponent<CameraController>();
		collider2D = GetComponentInChildren<BoxCollider2D>();
		ken = GameObject.Find("Ken").GetComponent<Ken>();

		healthBar = bossBarContainer.transform.Find("HealthBar").GetComponent<Image>();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		collider2D.enabled = false;
		foreach (SteelDoor steelDoor in steelDoorsToLock) // Lock doors
			steelDoor.shouldLock = true;
		bossBarContainer.SetActive(true); // Show boss bar
		cameraController.secondTarget = boss.transform; // Switch target to boss
		cameraController.cameraTargetWeightage = 0;
		LevelManager.Instance.isBossIntro = true;

		AudioManager.Instance.Stop(AudioEnum.Level4Theme);
		AudioManager.Instance.Play(AudioEnum.Alarm);
		AudioManager.Instance.Play(AudioEnum.BossTheme);
		animator.Play("TerminalIntroSequence");
	}

	public void TriggerBossIntroSequence()
	{
		boss.animator.SetTrigger(boss.nextPhaseTriggerParameter);
	}

	public void BossInit()
	{
		AudioManager.Instance.Stop(AudioEnum.Alarm);
		AudioManager.Instance.Play(AudioEnum.Regenerate);
		StartCoroutine(InitBossHealth());
	}

	private IEnumerator InitBossHealth()
	{
		float timeElapsed = 0;
		while (true)
		{
			timeElapsed += Time.deltaTime;
			healthBar.fillAmount = Mathf.Min(timeElapsed / 3.4F, 1);
			if (healthBar.fillAmount == 1)
				break;
			yield return new WaitForEndOfFrame();
		}
		boss.animator.SetTrigger(boss.nextPhaseTriggerParameter);
		LevelManager.Instance.isBossIntro = false;
		LevelManager.Instance.isBossReady = true;

		cameraController.cameraTargetWeightage = 1;
		cameraController.camSize = 6;

	}
}
