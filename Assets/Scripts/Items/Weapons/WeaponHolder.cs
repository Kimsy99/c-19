using System;
using UnityEngine;

/*
 * This is a class for the character to hold the weapon
 */
public class WeaponHolder : MonoBehaviour
{
	public static Action OnStartShooting;

	[Header("Weapon Settings")]
	[SerializeField] private Weapon weaponToUse;
	[SerializeField] private Transform weaponHolderPosition;

	private KenShooting shooting;
	private WeaponAim weaponAim;

	// Reference of the Weapon we are using
	public Weapon CurrentWeapon { get; set; }

	void Awake()
	{
		shooting = GetComponent<KenShooting>();
		EquipWeapon(weaponToUse, weaponHolderPosition);
	}

	// test code to test the functionality to equip new weapon
	/*[SerializeField] private Weapon secondWeapon;
	private int i = 1;
	private void Update()
	{
		if (i == 1)
		{
			EquipWeapon(secondWeapon, weaponHolderPosition);
			--i;
		}
	}*/

	private void EquipWeapon(Weapon weapon, Transform weaponPosition)
	{
		if (CurrentWeapon != null)
		{
			weaponAim.DestroyReticle();
			Destroy(CurrentWeapon.gameObject);
		}

		CurrentWeapon = Instantiate(weapon, weaponPosition.position, weaponPosition.rotation);
		CurrentWeapon.transform.parent = weaponPosition;
		weaponAim = CurrentWeapon.GetComponent<WeaponAim>();
		shooting.SetNewWeapon(CurrentWeapon.GetComponent<Weapon>(), CurrentWeapon.GetComponent<WeaponAim>());
	}
}