/// <summary>
/// Data structure for weapons. Actual weapons (weapons in the world, weapons held in inventory,
/// and the weapon held by Ken) will read data from this.
/// </summary>
public class Weapon
{
	public WeaponSettings weaponSettings;
	/** Inventory slot for this item. If this item is not in inventory, this will be null. */
	public InventorySlot inventorySlot;
	public int bulletCount;

	public Weapon(WeaponSettings weaponSettings)
	{
		this.weaponSettings = weaponSettings;
		bulletCount = weaponSettings.maxBulletCount;
	}
}
