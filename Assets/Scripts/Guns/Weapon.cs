using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class is to control the movement of weapon
 * However, the rotation of the weapon is controlled by WeaponAim
 */

public class Weapon : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] private ParticleSystem muzzlePS;

    // Reference of the Character that controls this Weapon
    public Character WeaponOwner { get; set; }

    private Animator animator;
    private readonly int weaponUseParameter = Animator.StringToHash("WeaponUse");


    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        RotateWeapon();
    }

    // Reference the owner of this Weapon
    public void SetOwner(Character owner)
    {
        WeaponOwner = owner;
    }

    protected virtual void RotateWeapon()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
}
