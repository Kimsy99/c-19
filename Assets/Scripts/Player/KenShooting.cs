﻿using System;
using UnityEngine;

[Obsolete("Going to replace with KenUseItem")]
public class KenShooting : Movable2D
{
	private Camera cam;
	private Vector2 mousePos = new Vector2();

	private WeaponAim weaponAim;
	private Weapon weapon;

	private Vector3 spawnPosition;

	protected override void Awake()
	{
		base.Awake();
	}

	void Start()
	{
		cam = Camera.main;
	}

	// Update is called once per frame
	void Update()
	{
		//mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		//if (Input.GetButtonDown("Fire1"))
		//	Shoot();

		//if(weaponAim == null)
		//	weaponAim = GetComponentInChildren<WeaponAim>();

		//if (weapon == null)
		//	weapon = GetComponentInChildren<Weapon>();
	}

    private void Shoot() //shoot with updated position
    {
		// Obtain angle from Ken to mouse
		//spawnPosition = weaponAim.EvaluateProjectileSpawnPosition();
		//Vector2 lookDirection = mousePos - (Vector2)spawnPosition;
  //      float angle = Vector2.SignedAngle(Vector2.right, lookDirection);

  //      // Actually create the bullet
  //      Movable2D bullet = Instantiate<Movable2D>(bulletPrefab, spawnPosition, Quaternion.identity);
  //      bullet.Speed = bulletSpeed;
  //      bullet.Direction = angle;
		//weapon.TriggerShootingEffect();
    }
}
