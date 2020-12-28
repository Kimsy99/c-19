using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Movable2D
{
	private BossHealth boss1;
	private NPCHurtOnCollide colliderNPC;

	[SerializeField] private GameObject[] doorsToUnlock = null;

	// Start is called before the first frame update
	protected override void Awake()
	{
		base.Awake();
		boss1 = GetComponent<BossHealth>();
		colliderNPC = GetComponent<NPCHurtOnCollide>();
		boss1.OnDie += Dead; //action
	}

	private void Dead()
	{
		Speed = 0;
		colliderNPC.enabled = false;
		LevelManager.Instance.ExitBossMode();
		AudioManager.Instance.Stop(AudioEnum.BossTheme);
		Destroy(GetComponent<BoxCollider2D>());

		foreach (GameObject gameObject in doorsToUnlock)
			gameObject.SetActive(false);
	}
}
