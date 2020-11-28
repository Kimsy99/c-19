﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    [SerializeField] private GameObject reticlePrefab;

    // Returns the current absolute angle
    public float CurrentAimAngleAbsolute { get; set; }

    // Returns the current angle
    public float CurrentAimAngle { get; set; }

    private Camera mainCamera;
    private GameObject reticle;

    private Vector3 direction;
    private Vector3 mousePosition;
    private Vector3 reticlePosition;
    private Vector3 currentAim = Vector3.zero;
    private Vector3 currentAimAbsolute = Vector3.zero;
    private Quaternion initialRotation;
    private Quaternion lookRotation;

    //character movement
    private SpriteFlippable2D characterMovingDirection;

    private void Start()
    {
        Cursor.visible = false;
        initialRotation = transform.rotation;

        characterMovingDirection = GetComponentInParent<SpriteFlippable2D>();

        mainCamera = Camera.main;
        reticle = Instantiate(reticlePrefab);
    }

    private void Update()
    {
        GetMousePosition();
        MoveReticle();
        RotateWeapon();
    }

    // Get the exact mouse position in order to aim
    private void GetMousePosition()
    {
        // Get Mouse Position
        mousePosition = Input.mousePosition;
        mousePosition.z = 5f;  // We set this value to ensure the camera always stays infront to view everything in game

        // Get World space position
        direction = mainCamera.ScreenToWorldPoint(mousePosition);
        direction.z = transform.position.z;
        reticlePosition = direction;

        currentAimAbsolute = direction - transform.position;
        if (characterMovingDirection.Direction == 0)
        {   //character facing right
            currentAim = direction - transform.position;
        }
        else if (characterMovingDirection.Direction == 180)
        {   //character facing left
            currentAim = transform.position - direction;
        }
    }

    public void RotateWeapon()
    {
        if (currentAim != Vector3.zero && direction != Vector3.zero)
        {
            // Get Angle
            CurrentAimAngle = Mathf.Atan2(currentAim.y, currentAim.x) * Mathf.Rad2Deg;
            CurrentAimAngleAbsolute = Mathf.Atan2(currentAimAbsolute.y, currentAimAbsolute.x) * Mathf.Rad2Deg;

            CurrentAimAngle = Mathf.Clamp(CurrentAimAngle, -180, 180);

            // Apply the angle
            lookRotation = Quaternion.Euler(CurrentAimAngle * Vector3.forward);
            transform.rotation = lookRotation;
        }
        else
        {
            CurrentAimAngle = 0f;  // If the mouse is not moving at all at the beginning
            transform.rotation = initialRotation;
        }
    }

    // Moves our reticle towards our Mouse Position
    private void MoveReticle()
    {
        reticle.transform.rotation = Quaternion.identity; //set the normal rotation
        reticle.transform.position = reticlePosition;
    }
}