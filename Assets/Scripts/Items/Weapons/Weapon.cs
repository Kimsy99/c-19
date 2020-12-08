using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class is to control the characteristics of weapon
 * and its animation when shooting
 * note: The rotation of the weapon is controlled by WeaponAim
 */

public class Weapon : MonoBehaviour
{
    [Header("Bullet")]
    [SerializeField] public Bullet bulletToUse;
    [SerializeField] private float bulletSpeed = 10F;
    [SerializeField] private int maxBullet = 10;
    [SerializeField] private int damageValue = 1;
    [SerializeField] private int spread = 20;
    
    [Header("Effects")]
    [SerializeField] private ParticleSystem muzzlePS;

    // Reference of the Character that controls this Weapon
    public Character WeaponOwner { get; set; }

    private Animator animator;
    private readonly int weaponUseParameter = Animator.StringToHash("WeaponUse");

    private int currentBullet;

    // Provide access to internal data
    public int CurrentBullet => currentBullet;
    public int DamageValue => damageValue;
    public float BulletSpeed => bulletSpeed;
    public int Spread => spread;

    protected void Awake()
    {
        animator = GetComponent<Animator>();
        currentBullet = maxBullet;
    }

    protected virtual void Update()
    {

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
