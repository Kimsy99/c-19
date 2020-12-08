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
    [SerializeField] public Bullet bulletToUse;
    [SerializeField] private int maxBullet = 10;

    [Header("Damage")]
    [SerializeField] public int damageValue = 1;
    
    [Header("Effects")]
    [SerializeField] private ParticleSystem muzzlePS;

    // Reference of the Character that controls this Weapon
    public Character WeaponOwner { get; set; }

    private Animator animator;
    private readonly int weaponUseParameter = Animator.StringToHash("WeaponUse");

    private int currentBullet;
    public int CurrentBullet => currentBullet;

    protected void Awake()
    {
        animator = GetComponent<Animator>();
        currentBullet = maxBullet;
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

    public bool ConsumeAmmo()
    {
        if(currentBullet > 0)
        {
            --currentBullet;
            return true;
        }
        else
        {
            return false;
        }
    }
}
