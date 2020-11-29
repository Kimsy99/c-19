using UnityEngine;

public class KenShooting : Movable2D
{
	[SerializeField] private Movable2D bulletPrefab;
	[SerializeField] private Transform ShootingPoint;
	[SerializeField] private float bulletSpeed = 10F;

	[SerializeField] private Camera cam;
	private Vector2 mousePos = new Vector2();

	private WeaponAim weaponAim;
	private Weapon weapon;

    // Update is called once per frame
    void Update()
	{
		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		if (Input.GetButtonDown("Fire1"))
			Shoot();

		if(weaponAim == null)
			weaponAim = GetComponentInChildren<WeaponAim>();

		if (weapon == null)
			weapon = GetComponentInChildren<Weapon>();
	}

    /*private void Shoot()
	{
		// Obtain angle from Ken to mouse
		Vector2 lookDirection = mousePos - body.position;
		float angle = Vector2.SignedAngle(Vector2.right, lookDirection);

		// Actually create the bullet
		Movable2D bullet = Instantiate<Movable2D>(bulletPrefab, ShootingPoint.position, Quaternion.identity);
		bullet.Speed = bulletSpeed;
		bullet.Direction = angle;
	}*/

    private void Shoot() //shoot with updated position
    {
        // Obtain angle from Ken to mouse
        Vector2 lookDirection = mousePos - body.position;
        float angle = Vector2.SignedAngle(Vector2.right, lookDirection);

        // Actually create the bullet
        Movable2D bullet = Instantiate<Movable2D>(bulletPrefab, weaponAim.EvaluateProjectileSpawnPosition(), Quaternion.identity);
        bullet.Speed = bulletSpeed;
        bullet.Direction = angle;
		weapon.TriggerShootAnimation();
    }
}
