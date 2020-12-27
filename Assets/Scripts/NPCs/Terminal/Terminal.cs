using System.Collections;
using UnityEngine;

public class Terminal : MonoBehaviour
{
	[HideInInspector] public Animator animator;
	public readonly int nextPhaseTriggerParameter = Animator.StringToHash("NextPhase");
	private readonly int phaseParameter = Animator.StringToHash("Phase");

	private Ken ken;
	public float time;
	public Turret[] turretSet1;
	public Turret[] turretSet2;
	public Turret[] turretSet3;

	[SerializeField] private TerminalWarningLaser terminalWarningLaser = null;
	[SerializeField] private TerminalLaser terminalLaser = null;
	[SerializeField] private GameObject explosionEffect = null;
	[SerializeField] private GameObject terminalExplosionEffect = null;
	[SerializeField] private GameObject explosionBlackness = null;
	[SerializeField] private GameObject lights = null;
	[SerializeField] private SteelDoor[] steelDoorsToUnlock = null;

	void Awake()
	{
		ken = FindObjectOfType<Ken>();
		animator = GetComponent<Animator>();
		GetComponent<BossHealth>().OnDie += Die;
	}

	public void SetPhase(int phase)
	{
		animator.SetInteger(phaseParameter, phase);
	}

	private Turret[] GetTurretSet(int index)
	{
		switch (index)
		{
			case 1:
				return turretSet1;
			case 2:
				return turretSet2;
			case 3:
				return turretSet3;
		}
		return null;
	}

	public void ActivateTurretSet(int index)
	{
		Turret[] turretSet = GetTurretSet(index);
		foreach (Turret turret in turretSet)
			turret.Activated = true;
	}

	public void DeactivateTurretSet(int index)
	{
		Turret[] turretSet = GetTurretSet(index);
		foreach (Turret turret in turretSet)
			turret.Activated = false;
	}

	public void FireTurretSet(int turretIndex)
	{
		switch (turretIndex)
		{
			case 1:
				StartCoroutine(FireTurretSet1());
				break;
			case 2:
				StartCoroutine(FireTurretSet2());
				break;
			case 3:
				StartCoroutine(FireTurretSet3());
				break;
		}
	}

	private IEnumerator FireTurretSet1()
	{
		ShootTurret(turretSet1[0]);
		yield return new WaitForSeconds(1 / 6F);
		ShootTurret(turretSet1[1]);
		yield return new WaitForSeconds(1 / 6F);
		ShootTurret(turretSet1[2]);
		yield return new WaitForSeconds(1 / 6F);
		ShootTurret(turretSet1[3]);
		yield return new WaitForSeconds(1 / 3F);
		ShootTurret(turretSet1[0]);
		yield return new WaitForSeconds(1 / 6F);
		ShootTurret(turretSet1[1]);
		yield return new WaitForSeconds(1 / 6F);
		ShootTurret(turretSet1[2]);
		yield return new WaitForSeconds(1 / 6F);
		ShootTurret(turretSet1[3]);
	}

	private IEnumerator FireTurretSet2()
	{
		ShootTurret(turretSet2[0]);
		yield return new WaitForSeconds(1 / 6F);
		ShootTurret(turretSet2[1]);
		yield return new WaitForSeconds(1 / 6F);
		ShootTurret(turretSet2[2]);
		yield return new WaitForSeconds(1 / 6F);
		ShootTurret(turretSet2[1]);
		yield return new WaitForSeconds(1 / 3F);
		ShootTurret(turretSet2[0]);
		yield return new WaitForSeconds(1 / 6F);
		ShootTurret(turretSet2[1]);
		yield return new WaitForSeconds(1 / 6F);
		ShootTurret(turretSet2[2]);
		yield return new WaitForSeconds(1 / 6F);
		ShootTurret(turretSet2[1]);
	}

	private IEnumerator FireTurretSet3()
	{
		ShootTurret(turretSet3[0]);
		yield return new WaitForSeconds(1 / 6F);
		ShootTurret(turretSet3[1]);
		yield return new WaitForSeconds(1 / 6F);
		ShootTurret(turretSet3[2]);
		yield return new WaitForSeconds(1 / 6F);
		ShootTurret(turretSet3[1]);
		yield return new WaitForSeconds(1 / 3F);
		ShootTurret(turretSet3[0]);
		yield return new WaitForSeconds(1 / 6F);
		ShootTurret(turretSet3[1]);
		yield return new WaitForSeconds(1 / 6F);
		ShootTurret(turretSet3[2]);
		yield return new WaitForSeconds(1 / 6F);
		ShootTurret(turretSet3[1]);
	}

	private void ShootTurret(Turret turret)
	{
		turret.Shoot();
		AudioManager.Instance.PlayOneShot(AudioEnum.TurretShoot);
	}

	public void StartProjectWarningLaser()
	{
		StartCoroutine(ProjectWarningLaser());
	}

	private IEnumerator ProjectWarningLaser()
	{
		Vector2 directionVector = ken.center.transform.position - transform.position;
		float direction = -90 + Mathf.Clamp(Vector2.SignedAngle(Vector2.down, directionVector), -30, 30);
		const float separation = 15;

		AudioManager.Instance.Play(AudioEnum.Blip);
		for (int i = 0; i < 7; i++)
			CreateWarningLaser(direction + (i - 3) * separation);
		yield return new WaitForSeconds(0.4F);
		AudioManager.Instance.Play(AudioEnum.Blip);
		for (int i = 0; i < 8; i++)
			CreateWarningLaser(direction + (i - 4) * separation + separation / 2);
		yield return new WaitForSeconds(0.4F);
		AudioManager.Instance.Play(AudioEnum.Blip);
		for (int i = 0; i < 7; i++)
			CreateWarningLaser(direction + (i - 3) * separation);
		yield return new WaitForSeconds(0.8F);

		AudioManager.Instance.Play(AudioEnum.TerminalLaser);
		for (int i = 0; i < 7; i++)
			CreateTerminalLaser(direction + (i - 3) * separation);
		yield return new WaitForSeconds(0.4F);
		AudioManager.Instance.Play(AudioEnum.TerminalLaser);
		for (int i = 0; i < 8; i++)
			CreateTerminalLaser(direction + (i - 4) * separation + separation / 2);
		yield return new WaitForSeconds(0.4F);
		AudioManager.Instance.Play(AudioEnum.TerminalLaser);
		for (int i = 0; i < 7; i++)
			CreateTerminalLaser(direction + (i - 3) * separation);
	}

	private void CreateWarningLaser(float direction)
	{
		TerminalWarningLaser terminalWarningLaser = Instantiate<TerminalWarningLaser>(this.terminalWarningLaser, transform.position, Quaternion.identity, transform);
		terminalWarningLaser.direction = direction;
	}

	private void CreateTerminalLaser(float direction)
	{
		TerminalLaser terminalLaser = Instantiate<TerminalLaser>(this.terminalLaser, transform.position, Quaternion.identity, transform);
		terminalLaser.direction = direction;
	}

	public void DoNothing() {}

	private void Die()
	{
		gameObject.layer = LayerMask.NameToLayer("Wall");
		GetComponent<BossHealth>().OnDie -= Die;
		Destroy(transform.Find("Colliders").Find("Enemy").gameObject);
		StopAllCoroutines();
		Instantiate(explosionEffect, transform.position, Quaternion.identity, transform);
	}

	public void PlayExplosionSound()
	{
		AudioManager.Instance.Play(AudioEnum.Explosion);
	}

	public void Finish()
	{
		AudioManager.Instance.Play(AudioEnum.BigExplosion);
		AudioManager.Instance.Play(AudioEnum.PowerDown);
		AudioManager.Instance.Stop(AudioEnum.BossTheme);
		AudioManager.Instance.Play(AudioEnum.Level4Theme);
		Instantiate(terminalExplosionEffect, transform.position, Quaternion.identity, transform);
		Instantiate(explosionBlackness, transform.position, Quaternion.identity, transform);
		Destroy(lights);

		LevelManager.Instance.ExitBossMode();

		foreach (SteelDoor steelDoor in steelDoorsToUnlock) // Unlock doors
			steelDoor.isOpen = true;
	}
}
