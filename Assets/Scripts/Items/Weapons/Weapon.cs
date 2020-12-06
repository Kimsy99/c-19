using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class is to control the movement of weapon
 * note: The rotation of the weapon is controlled by WeaponAim
 */

public class Weapon : MonoBehaviour
{
    [Header("Bullet")]
    [SerializeField] public Movable2D bulletToUse;

    [Header("Damage")]
    [SerializeField] public int damageValue = 1;
    
    [Header("Effects")]
    [SerializeField] private ParticleSystem muzzlePS;

    // Reference of the Character that controls this Weapon
    public Character WeaponOwner { get; set; }

    private Animator animator;
    private readonly int weaponUseParameter = Animator.StringToHash("WeaponUse");

    protected void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {

    }

    // Reference the owner of this Weapon
    public void SetOwner(Character owner)
    {
        WeaponOwner = owner;
    }

    public void TriggerShootingEffect()
    {
        animator.SetTrigger(weaponUseParameter);
        muzzlePS.Play();
    }
}
