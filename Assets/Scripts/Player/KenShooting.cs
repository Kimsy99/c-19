﻿using UnityEngine;

public class KenShooting : Movable2D
{
	[SerializeField] private Movable2D bulletPrefab;
	[SerializeField] private Transform ShootingPoint;
	[SerializeField] private float bulletSpeed = 10F;

	[SerializeField] private Camera cam;
	private Vector2 mousePos = new Vector2();

	private WeaponAim weaponAim;
	private Weapon weapon;

	private Vector3 spawnPosition;

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

    private void Shoot() //shoot with updated position
    {
		// Obtain angle from Ken to mouse
		spawnPosition = weaponAim.EvaluateProjectileSpawnPosition();
		Vector2 lookDirection = mousePos - (Vector2)spawnPosition;
        float angle = Vector2.SignedAngle(Vector2.right, lookDirection);
		//Debug.Log("Original angle: " + angle);
		angle += Random.Range(-20, 30) / 10;
		//Debug.Log(angle);

        // Actually create the bullet
        Movable2D bullet = Instantiate<Movable2D>(bulletPrefab, spawnPosition, Quaternion.identity);
        bullet.Speed = bulletSpeed;
        bullet.Direction = angle;
		weapon.TriggerShootingEffect();
    }
}
