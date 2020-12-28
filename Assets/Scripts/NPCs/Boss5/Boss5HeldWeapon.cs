public class Boss5HeldWeapon : NPCHeldWeapon
{
	public override void Shoot() //shoot with updated position
	{
		if (bulletToUse == null)
			return;

		// Bullet will randomly go slightly upward of downward
		//float shootingAngle = weaponAim.AimAngle;

		// Actually create the bullet
		TriggerShootingEffect();
		for (int i = 0; i < 360; i += 20)
		{
			//Debug.Log(i);
			CreateBullet(i, bulletSpeed, bulletDamage);
		}
		// AudioManager.Instance.Play(WeaponSettings.shootSound);
	}
}
