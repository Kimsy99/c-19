using UnityEngine;

public class NPC : MonoBehaviour
{
    [HideInInspector] public NPCHealth health;
    [HideInInspector] public SpriteFlippable2D spriteFlippable2D;
    [HideInInspector] public NPCMovement movement;
    [HideInInspector] public NPCHeldWeapon heldWeapon;

    void Awake()
    {
        health = GetComponent<NPCHealth>();
        spriteFlippable2D = GetComponent<SpriteFlippable2D>();
        movement = GetComponent<NPCMovement>();
		heldWeapon = GetComponentInChildren<NPCHeldWeapon>();
    }
}
