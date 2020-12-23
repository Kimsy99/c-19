using System.Collections;
using UnityEngine;

public class NPCHeldWeapon : MonoBehaviour
{
	private NPCWeaponAim weaponAim;
	private Animator animator;
	private readonly int UseWeaponParameter = Animator.StringToHash("UseWeapon");
	[SerializeField] private Transform bulletSpawner = null;
	[SerializeField] private ParticleSystem muzzlePS = null;

	[SerializeField] private EnemyBullet bulletToUse = null;
	[SerializeField] private float bulletSpeed = 1;
	[SerializeField] private float bulletDamage = 1;

	void Awake()
	{
		weaponAim = GetComponentInParent<NPCWeaponAim>();
		animator = GetComponent<Animator>();
	}

	public void TriggerShootingEffect()
	{
		animator.SetTrigger(UseWeaponParameter);
		if (muzzlePS != null)
			muzzlePS.Play();
	}

	public void Shoot() //shoot with updated position
	{
		if (bulletToUse == null)
			return;

		// Bullet will randomly go slightly upward of downward
		float shootingAngle = weaponAim.AimAngle;

		// Actually create the bullet
		TriggerShootingEffect();
		CreateBullet(shootingAngle, bulletSpeed, bulletDamage);
		//AudioManager.Instance.Play(WeaponSettings.shootSound);
	}

	private void CreateBullet(float direction, float speed, float damage)
	{
		EnemyBullet bullet = Instantiate(bulletToUse, bulletSpawner.transform.position, Quaternion.identity);
		bullet.Speed = speed;
		bullet.Direction = direction;
		bullet.SetDamage(damage);
		//bullet.SetOwnerTag(tag); // Indicate the shooter of the bullet
	}
}
