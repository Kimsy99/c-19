using UnityEngine;

public class KenShooting : Movable2D
{
	[SerializeField] private float bulletSpeed = 10F;

	[SerializeField] private Camera cam;
	private Vector2 mousePos = new Vector2();

	private WeaponAim weaponAim;
	private Weapon weapon;

	// The bullet depends on what type of weapon is used 
	private Movable2D bulletPrefab;

	private Vector3 spawnPosition;

    private void Start()
    {
		weaponAim = GetComponentInChildren<WeaponAim>();
		weapon = GetComponentInChildren<Weapon>();
		bulletPrefab = weapon.bulletToUse;
	}

    // Update is called once per frame
    void Update()
	{
		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		if (Input.GetButtonDown("Fire1"))
			Shoot();
	}

    private void Shoot() //shoot with updated position
    {
		// Obtain angle from Ken to mouse
		spawnPosition = weaponAim.EvaluateProjectileSpawnPosition();
		Vector2 lookDirection = mousePos - (Vector2)spawnPosition;
        float angle = Vector2.SignedAngle(Vector2.right, lookDirection);
		
		// bullet will randomly go slightly upward of downward
		angle += Random.Range(-20, 30) / 10;

        // Actually create the bullet
        Movable2D bullet = Instantiate<Movable2D>(bulletPrefab, spawnPosition, Quaternion.identity);
        bullet.Speed = bulletSpeed;
        bullet.Direction = angle;
		weapon.TriggerShootingEffect();
    }
}
