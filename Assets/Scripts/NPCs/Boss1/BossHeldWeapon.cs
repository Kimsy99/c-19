﻿public class BossHeldWeapon : NPCHeldWeapon
{
	public override void Shoot() //shoot with updated position
	{
		if (bulletToUse == null)
			return;

		// Bullet will randomly go slightly upward of downward
		float shootingAngle = weaponAim.AimAngle;

		// Actually create the bullet
		TriggerShootingEffect();
		for (int i = 0; i < 51; i += 15)
		{
			//Debug.Log(i);
			CreateBullet(shootingAngle + i, bulletSpeed, bulletDamage);
			CreateBullet(shootingAngle - i, bulletSpeed, bulletDamage);
		}
		// AudioManager.Instance.Play(WeaponSettings.shootSound);
	}
}
