using UnityEngine;

public class Boss4Trigger : MonoBehaviour
{
	[SerializeField] private SteelDoor[] steelDoorsToLock = null;
	[SerializeField] private Terminal boss = null;

	private Animator animator;
	private new BoxCollider2D collider2D;

	void Awake()
	{
		animator = GetComponent<Animator>();
		collider2D = GetComponentInChildren<BoxCollider2D>();

		LevelManager.Instance.OnBossBarPostInit += BossHealthPostInit;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		collider2D.enabled = false;
		foreach (SteelDoor steelDoor in steelDoorsToLock) // Lock doors
			steelDoor.isOpen = false;
		LevelManager.Instance.IntroBoss(boss.gameObject);

		AudioManager.Instance.Stop(AudioEnum.Level4Theme);
		AudioManager.Instance.Play(AudioEnum.Alarm);
		animator.Play("TerminalIntroSequence");
	}

	public void TriggerBossIntroSequence()
	{
		boss.animator.SetTrigger(boss.nextPhaseTriggerParameter);
	}

	public void BossInit()
	{
		AudioManager.Instance.Stop(AudioEnum.Alarm);
		LevelManager.Instance.InitBossHealthBar();
	}

	private void BossHealthPostInit()
	{
		boss.animator.SetTrigger(boss.nextPhaseTriggerParameter);
		boss.SetPhase(1);
	}
}
