using UnityEngine;

public class BossTrigger : MonoBehaviour
{
	[SerializeField] private GameObject[] bossDoorsToLock = null;
	[SerializeField] protected GameObject boss = null;

	protected Animator animator;
	protected new BoxCollider2D collider2D;

	// Use this for initialization
	protected virtual void Awake()
	{
		animator = GetComponent<Animator>();
		collider2D = GetComponentInChildren<BoxCollider2D>();
	}

	protected virtual void OnTriggerEnter2D(Collider2D collision)
	{
		collider2D.enabled = false;
		LevelManager.Instance.IntroBoss(boss.gameObject);

		foreach (GameObject bossDoor in bossDoorsToLock) // Lock doors
			bossDoor.SetActive(true);
		AudioManager.Instance.Stop(LevelManager.Instance.levelThemeEnum);
		Invoke(nameof(BossInit), 4);
	}

	public virtual void BossInit()
	{
		LevelManager.Instance.InitBossHealthBar();
	}
}
