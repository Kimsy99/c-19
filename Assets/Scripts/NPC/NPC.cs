using UnityEngine;

public class NPC : MonoBehaviour
{
    [HideInInspector] public NPCHealth health;
    [HideInInspector] public NPCMovement movement;
    [HideInInspector] public NPCHeldWeapon heldWeapon;

    void Start()
    {
        health = GetComponent<NPCHealth>();
        movement = GetComponent<NPCMovement>();
		heldWeapon = GetComponentInChildren<NPCHeldWeapon>();
    }
}
