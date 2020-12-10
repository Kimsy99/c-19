using UnityEngine;

public class Weapon : Item
{
    [Header("Settings")]
    [SerializeField] private Movable2D bulletPrefab;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float bulletSpeed = 10F;
    [SerializeField] private ParticleSystem muzzlePS;

    private Animator animator;
    private readonly int weaponUseParameter = Animator.StringToHash("WeaponUse");

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Use()
	{
        animator.SetTrigger(weaponUseParameter);
        muzzlePS.Play();
	}
}
