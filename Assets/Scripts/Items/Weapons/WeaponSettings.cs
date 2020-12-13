using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Settings")]
public class WeaponSettings : ScriptableObject
{
	/** Display name for use in the inventory. */
	public string displayName;
	/** Sprite to use in inventory and on ground. */
	public Sprite displaySprite;
	/** Sprite to use when held by Ken. */
	public Sprite heldSprite;

	/** Bullet prefab to use for this weapon. */
	public Bullet bulletToUse;
	/** Vector2 position relative to pivot for bullet and particle spawning. */
	public Vector2 bulletSpawnPositionOffset;
	public float bulletSpeed;
	/** Maximum number of bullets this weapon has, set it to -1 for infinite ammo. */
	public int maxBulletCount;
	public float damage;
	public int spread;
	public SoundEnum shootSound;
	public float cooldown;
	public ParticleSystem muzzlePS;
	public GameObject customBulletSpawner;
}
