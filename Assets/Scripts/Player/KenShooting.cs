using System;
using UnityEngine;

[Obsolete("Going to replace with KenUseItem")]
public class KenShooting : Movable2D
{
	private Camera cam;
	private Vector2 mousePos = new Vector2();

	private WeaponAim weaponAim;
	private Weapon weapon;

	// The bullet depends on what type of weapon is used 
	private Bullet bulletPrefab;

	private Vector3 spawnPosition;

	protected override void Awake()
	{
		base.Awake();
		cam = Camera.main;
	}

	// Update is called once per frame
	void Update()
	{
		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		if (Input.GetButtonDown("Fire1"))
			Shoot();
	}

	public void SetNewWeapon(Weapon newWeapon, WeaponAim newWeaponAim)
    {
		weapon = newWeapon;
		weaponAim = newWeaponAim;
		bulletPrefab = weapon.bulletToUse;
	}

    private void Shoot() //shoot with updated position
    {
		// Check if still have bullet
		if(weapon.ConsumeAmmo())
        {
			// Obtain angle from Ken to mouse
			spawnPosition = weaponAim.EvaluateProjectileSpawnPosition();
			Vector2 lookDirection = mousePos - (Vector2)spawnPosition;
			float angle = Vector2.SignedAngle(Vector2.right, lookDirection);

			// bullet will randomly go slightly upward of downward
			angle += Random.Range(-weapon.Spread, weapon.Spread) / 10;

			// Actually create the bullet
			Bullet bullet = Instantiate<Bullet>(bulletPrefab, spawnPosition, Quaternion.identity);
			bullet.Speed = weapon.BulletSpeed;
			bullet.Direction = angle;
			bullet.setDamage(weapon.DamageValue);
			bullet.SetOwnerTag(tag);    // indicate the shooter of the bullet
			weapon.TriggerShootingEffect();
		}
    }
}
