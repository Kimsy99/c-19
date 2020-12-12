using UnityEngine;

public class LevelManager : MonoBehaviour
{
	private HeldWeapon heldWeapon;
	[SerializeField] private Transform spawnPosition;

	[SerializeField] private WeaponSettings firstWeaponSettings;
	[SerializeField] private WeaponSettings secondWeaponSettings;
	[SerializeField] private WeaponSettings thirdWeaponSettings;

	void Awake()
	{
		heldWeapon = GameObject.Find("HeldWeapon").GetComponent<HeldWeapon>();
	}

	void Start()
	{
		Weapon firstWeapon = new Weapon(firstWeaponSettings);
		InventoryManager.Instance.SetWeapon(0, firstWeapon);
		InventoryManager.Instance.SetWeapon(1, new Weapon(secondWeaponSettings));
		InventoryManager.Instance.SetWeapon(2, new Weapon(thirdWeaponSettings));
		heldWeapon.SetHeldWeapon(firstWeapon);
	}
}
