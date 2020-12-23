using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete("Use Movable2D.Direction and Movable2D.Speed for movement")]
public class NPCMovementAI //: NPCComponents
{
    //[SerializeField] private float walkSpeed = 6f;

    //// A property is a method to store / return a value. In this case, its to controls our current move speed
    //public float MoveSpeed { get; set; }

    //// Internal
    //private readonly int movingParamater = Animator.StringToHash("Moving");
    
    //protected override void Start()
    //{
    //    base.Start();
    //    MoveSpeed = walkSpeed;
    //}

    //protected override void HandleAbility()
    //{
    //    base.HandleAbility();
    //    MoveNPC();
    //    UpdateAnimations();
    //}

    //// Moves our character by our current speed
    //private void MoveNPC()
    //{
    //    Vector2 movement = new Vector2(horizontalInput, verticalInput);
    //    Vector2 moveInput = movement;
    //    Vector2 movementNormalized = moveInput.normalized;
    //    Vector2 movementSpeed = movementNormalized * MoveSpeed;
    //    controller.SetMovement(movementSpeed);
    //}

    //// Updates our Idle and Move animation
    //private void UpdateAnimations()
    //{
    //    if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
    //    {
    //        if (npc.NPCAnimator != null)
    //        {
    //            npc.NPCAnimator.SetBool(movingParamater, true);
    //        }
    //    }
    //    else
    //    {
    //        if (npc.NPCAnimator != null)
    //        {
    //            npc.NPCAnimator.SetBool(movingParamater, false);
    //        }
    //    }
    //}

    //// Resets our speed from the run speed to the walk speed
    //public void ResetSpeed()
    //{
    //    MoveSpeed = walkSpeed;
    //}
    
    //public void SetHorizontal(float value)
    //{
    //    horizontalInput = value;
    //}

    //public void SetVertical(float value)
    //{
    //    verticalInput = value;
    //}
}
