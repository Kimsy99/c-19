using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCComponents : MonoBehaviour
{
    protected float horizontalInput;
    protected float verticalInput;

    protected NPCController controller;
    protected NPCMovement npcMovement;
    protected Animator animator;
    protected NPC npc;
    
    protected virtual void Start()
    {
        controller = GetComponent<NPCController>();
        npc = GetComponent<NPC>();
        npcMovement = GetComponent<NPCMovement>();
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        HandleAbility();
    }

    // Main method. Here we put the logic of each ability
    protected virtual void HandleAbility()
    {
        HandleInput();
    }
    
    // Here we get the necessary input we need to perform our actions
    protected virtual void HandleInput()
    {
        
    }
    
}
