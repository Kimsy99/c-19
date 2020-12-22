using UnityEngine;

public class LaserSpawner : Laser
{
	private WeaponAim weaponAim;
	public float damage;

	protected override void Awake()
	{
		base.Awake();
		weaponAim = GetComponentInParent<WeaponAim>();

		gameObject.SetActive(false);
	}

	void FixedUpdate()
	{
		ShootLaser(LayerMask.GetMask("Enemy", "Wall", "LaserPassableWall"), weaponAim.AimAngle);
	}

	protected override void OnLaserHit(RaycastHit2D hit)
	{
		if (hit.collider.gameObject.layer != LayerMask.NameToLayer("Enemy"))
			return;
		NPCHealth npcHealth = hit.collider.gameObject.GetComponentInParent<NPCHealth>();
		BossHealth bossHealth = hit.collider.gameObject.GetComponentInParent<BossHealth>();
		if (npcHealth != null)
			npcHealth.Damage(damage, true);
		else if (bossHealth != null)
			bossHealth.Damage(damage, true);
	}

	public bool IsLaserOn
	{
		get => gameObject.activeInHierarchy;
		set
		{
			gameObject.SetActive(value);
			if (value)
			{
				ShootLaser(LayerMask.GetMask("Enemy", "Wall", "LaserPassableWall"), weaponAim.AimAngle);
				AudioManager.Instance.Play(AudioEnum.Laser);
			}
			else
				AudioManager.Instance.Stop(AudioEnum.Laser);
		}
	}
}
