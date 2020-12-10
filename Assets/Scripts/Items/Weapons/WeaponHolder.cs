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

	protected Character character;

	// Reference of the Weapon we are using
	public Weapon CurrentWeapon { get; set; }

	protected void Start()
	{
		character = GetComponent<Character>();
		EquipWeapon(weaponToUse, weaponHolderPosition);
	}

	private void EquipWeapon(Weapon weapon, Transform weaponPosition)
	{
		CurrentWeapon = Instantiate(weapon, weaponPosition.position, weaponPosition.rotation);
		CurrentWeapon.transform.parent = weaponPosition;
	}
}