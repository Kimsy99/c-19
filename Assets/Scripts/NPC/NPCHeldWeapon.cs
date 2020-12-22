using UnityEngine;

public class NPCHeldWeapon : MonoBehaviour
{
	[SerializeField] protected NPCWeaponAim weaponAim;
	protected Animator animator;
	private readonly int UseWeaponParameter = Animator.StringToHash("UseWeapon");
	[SerializeField] protected Transform bulletSpawner = null;
	[SerializeField] protected ParticleSystem muzzlePS = null;

	[SerializeField] protected EnemyBullet bulletToUse = null;
	[SerializeField] protected float bulletSpeed = 1;
	[SerializeField] protected float bulletDamage = 1;

	protected virtual void Awake()
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

	public virtual void Shoot() //shoot with updated position
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

	protected void CreateBullet(float direction, float speed, float damage)
	{
		EnemyBullet bullet = Instantiate(bulletToUse, bulletSpawner.transform.position, Quaternion.identity);
		bullet.Speed = speed;
		bullet.Direction = direction;
		bullet.SetDamage(damage);
		//bullet.SetOwnerTag(tag); // Indicate the shooter of the bullet
	}
}
