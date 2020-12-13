using UnityEngine;

public class WeaponCollectable : MonoBehaviour
{
	[SerializeField] private WeaponSettings weaponSettings;
	private Weapon weapon;

	private Ken ken;
	private SpriteRenderer spriteRenderer;

	void Awake()
	{
		weapon = new Weapon(weaponSettings);

		ken = GameObject.Find("Ken").GetComponent<Ken>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = weapon.weaponSettings.displaySprite;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (Vector2.Distance(ken.transform.position, transform.position) < 1)
			{
				Weapon oldWeapon = InventoryManager.Instance.AddWeapon(weapon);
				AudioManager.Instance.Play(SoundEnum.Equip);
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
	}
}
