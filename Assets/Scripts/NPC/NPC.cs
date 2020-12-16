using UnityEngine;

public class NPC : MonoBehaviour
{
    [HideInInspector] public NPCHealth health;
    [HideInInspector] public NPCMovement movement;
    
    void Awake()
    {
        health = GetComponent<NPCHealth>();
        movement = GetComponent<NPCMovement>();
    }
}
