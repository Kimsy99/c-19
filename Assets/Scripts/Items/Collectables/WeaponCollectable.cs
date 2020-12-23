using UnityEngine;

public class WeaponCollectable : Collectable
{
	[SerializeField] private WeaponSettings weaponSettings = null;
	private Weapon weapon;

	private SpriteRenderer spriteRenderer;

	protected override void Awake()
	{
		base.Awake();
		weapon = new Weapon(weaponSettings);

		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = weapon.weaponSettings.displaySprite;
	}

	protected override void Collect()
	{
		Weapon oldWeapon = InventoryManager.Instance.AddWeapon(weapon);
		AudioManager.Instance.Play(AudioEnum.Equip);
		if (oldWeapon != null)
		{
			//transform.position = ken.transform.position;
			weapon = oldWeapon;
			spriteRenderer.sprite = oldWeapon.weaponSettings.displaySprite;
		}
		else
			Destroy(gameObject);
	}
}
