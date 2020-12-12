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
	[SerializeField] private Transform bulletSpawner;
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
		if (weapon != null)
			muzzlePS = Instantiate(weapon.weaponSettings.muzzlePS, bulletSpawner.transform);
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
		if (WeaponSettings.displayName.Equals("Trishot Pistol"))
		{
			TriggerShootingEffect();
			CreateBullet(shootingAngle, WeaponSettings.bulletSpeed, WeaponSettings.damage);
			CreateBullet(shootingAngle + 10, WeaponSettings.bulletSpeed, WeaponSettings.damage);
			CreateBullet(shootingAngle - 10, WeaponSettings.bulletSpeed, WeaponSettings.damage);
			SoundManager.Instance.Play(WeaponSettings.shootSound);
		}
		else
		{
			TriggerShootingEffect();
			CreateBullet(shootingAngle, WeaponSettings.bulletSpeed, WeaponSettings.damage);
			SoundManager.Instance.Play(WeaponSettings.shootSound);
		}

		if (Weapon.bulletCount == 0)
		{
			InventoryManager.Instance.RemoveWeapon(InventoryManager.Instance.ActiveSlotIndex);
			SetHeldWeapon(null);
		}
	}

	private void CreateBullet(float direction, float speed, float damage)
	{
		Bullet bullet = Instantiate(WeaponSettings.bulletToUse, bulletSpawner.transform.position, Quaternion.identity);
		bullet.Speed = speed;
		bullet.Direction = direction;
		bullet.SetDamage(damage);
		bullet.SetOwnerTag(tag); // Indicate the shooter of the bullet
	}
}
