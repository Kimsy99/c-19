using UnityEngine;

public class LevelManager : MonoBehaviour
{
	private HeldWeapon heldWeapon;
	[SerializeField] private WeaponSettings firstWeaponSettings = null;
	[SerializeField] private WeaponSettings secondWeaponSettings = null;
	[SerializeField] private WeaponSettings thirdWeaponSettings = null;

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
