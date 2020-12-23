using UnityEngine;

/// <summary>
/// Contains the weapon held by Ken and controls animations when shooting. <br/>
/// 
/// Note: The rotation of the weapon is controlled by WeaponAim.
/// </summary>
public class HeldWeapon : MonoBehaviour
{
	/** Data structure for the underlying weapon used. */
	public Weapon Weapon { get; private set; }
	private WeaponAim weaponAim;

	private SpriteRenderer spriteRenderer;
	private Animator animator;
	private readonly int UseWeaponParameter = Animator.StringToHash("UseWeapon");
	[SerializeField] private Transform bulletSpawner = null;
	private GameObject customSpawner;
	private LaserSpawner laserSpawner;
	private ParticleSystem muzzlePS;

	// Provide access to internal data
	public WeaponSettings WeaponSettings => Weapon?.weaponSettings;
	
	void Awake()
	{
		weaponAim = GetComponentInParent<WeaponAim>();

		spriteRenderer = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
		//muzzlePS = bulletSpawner.GetComponent<ParticleSystem>();
		InventoryManager.Instance.OnActiveSlotIndexChanged += OnActiveSlotIndexChanged;
	}

	void Start()
	{
		SetHeldWeapon(InventoryManager.Instance.GetWeapon(0));
	}

	private void OnActiveSlotIndexChanged(int index)
	{
		// Inventory active slot changed, set weapon
		SetHeldWeapon(InventoryManager.Instance.GetWeapon(index));
	}

	public void SetHeldWeapon(Weapon weapon)
	{
		Weapon = weapon;
		spriteRenderer.sprite = weapon?.weaponSettings.heldSprite;
		bulletSpawner.localPosition = weapon?.weaponSettings.bulletSpawnPositionOffset ?? Vector2.zero;
		if (muzzlePS != null)
			Destroy(muzzlePS.gameObject);
		if (customSpawner != null)
		{
			Destroy(customSpawner);
			if (laserSpawner != null)
			{
				laserSpawner.IsLaserOn = false;
				laserSpawner = null;
			}
		}

		if (weapon != null)
		{
			if(weapon.weaponSettings.muzzlePS!=null)
			muzzlePS = Instantiate(weapon.weaponSettings.muzzlePS, bulletSpawner.transform);
			if (weapon.weaponSettings.customBulletSpawner != null)
			{
				customSpawner = Instantiate(weapon.weaponSettings.customBulletSpawner, bulletSpawner.transform);
				laserSpawner = customSpawner.GetComponent<LaserSpawner>();
			}
		}
	}

	public void TriggerShootingEffect()
	{
		animator.SetTrigger(UseWeaponParameter);
		muzzlePS.Play();
	}

	public bool ConsumeAmmo()
	{
		if (Weapon.bulletCount > 0 || Weapon.weaponSettings.maxBulletCount == -1)
		{
			if (Weapon.weaponSettings.maxBulletCount != -1)
				Weapon.bulletCount--;
			if (Weapon.inventorySlot != null)
				Weapon.inventorySlot.UpdateSlot();
			return true;
		}
		return false;
	}

	public void Shoot() //shoot with updated position
	{
		if (!ConsumeAmmo())
			return;

		//Vector2 spawnerPosition = transform.position + Quaternion.Euler(0, 0, weaponAim.AimAngle) * WeaponSettings.bulletSpawnPositionOffset;
		//bulletSpawner.transform.position = spawnerPosition;

		// Bullet will randomly go slightly upward of downward
		float shootingAngle = weaponAim.AimAngle + Random.Range(-WeaponSettings.spread, WeaponSettings.spread);

		// Actually create the bullet
		switch (WeaponSettings.displayName)
		{
			case "Trishot Pistol":
				TriggerShootingEffect();
				CreateBullet(shootingAngle, WeaponSettings.bulletSpeed, WeaponSettings.damage);
				CreateBullet(shootingAngle + 10, WeaponSettings.bulletSpeed, WeaponSettings.damage);
				CreateBullet(shootingAngle - 10, WeaponSettings.bulletSpeed, WeaponSettings.damage);
				AudioManager.Instance.Play(WeaponSettings.shootSound);
				break;
			case "Laser Gun":
				if (!laserSpawner.IsLaserOn)
				{
					laserSpawner.IsLaserOn = true;
					laserSpawner.damage = WeaponSettings.damage;
				}
				break;
			default:
				TriggerShootingEffect();
				CreateBullet(shootingAngle, WeaponSettings.bulletSpeed, WeaponSettings.damage);
				AudioManager.Instance.Play(WeaponSettings.shootSound);
				break;
		}

		if (Weapon.bulletCount == 0)
		{
			InventoryManager.Instance.RemoveWeapon(InventoryManager.Instance.ActiveSlotIndex);
			SetHeldWeapon(null);
		}
	}

	public void DontShoot()
	{
		switch (WeaponSettings.displayName)
		{
			case "Laser Gun":
				if (laserSpawner.IsLaserOn)
					laserSpawner.IsLaserOn = false;
				break;
		}
	}

	private void CreateBullet(float direction, float speed, float damage)
	{
		Bullet bullet = Instantiate(WeaponSettings.bulletToUse, bulletSpawner.transform.position, Quaternion.identity);
		bullet.Speed = speed;
		bullet.Direction = direction;
		bullet.SetDamage(damage);
		bullet.ShotByWeaponName = WeaponSettings.displayName;
		//bullet.SetOwnerTag(tag); // Indicate the shooter of the bullet
	}
}
