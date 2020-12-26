using UnityEngine;

public class Boss4Trigger : BossTrigger
{
	[SerializeField] private SteelDoor[] steelDoorsToLock = null;
	private Terminal terminal;

	protected override void Awake()
	{
		base.Awake();
		LevelManager.Instance.OnBossBarPostInit += BossHealthPostInit;
		terminal = boss.GetComponent<Terminal>();
	}

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		collider2D.enabled = false;
		LevelManager.Instance.IntroBoss(boss.gameObject);

		AudioManager.Instance.Stop(LevelManager.Instance.levelThemeEnum);

		foreach (SteelDoor steelDoor in steelDoorsToLock) // Lock doors
			steelDoor.isOpen = false;
		AudioManager.Instance.Play(AudioEnum.Alarm);
		animator.Play("TerminalIntroSequence");
	}

	public void TriggerBossIntroSequence()
	{
		terminal.animator.SetTrigger(terminal.nextPhaseTriggerParameter);
	}

	public override void BossInit()
	{
		AudioManager.Instance.Stop(AudioEnum.Alarm);
		LevelManager.Instance.InitBossHealthBar();
	}

	private void BossHealthPostInit()
	{
		terminal.animator.SetTrigger(terminal.nextPhaseTriggerParameter);
		terminal.SetPhase(1);
	}
}
