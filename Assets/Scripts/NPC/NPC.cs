using UnityEngine;

public class NPC : MonoBehaviour
{
	[HideInInspector] public SpriteFlippable2D spriteFlippable2D;
	[HideInInspector] public Flashable flashable;
	[HideInInspector] public NPCHealth health;
	[HideInInspector] public NPCMovement movement;
	[HideInInspector] public GameObject weaponHolder;
	[HideInInspector] public NPCHeldWeapon heldWeapon;

	void Awake()
	{
		spriteFlippable2D = GetComponent<SpriteFlippable2D>();
		flashable = GetComponent<Flashable>();
		health = GetComponent<NPCHealth>();
		movement = GetComponent<NPCMovement>();
		weaponHolder = transform.Find("WeaponHolder").gameObject;
		heldWeapon = GetComponentInChildren<NPCHeldWeapon>();
	}
}
