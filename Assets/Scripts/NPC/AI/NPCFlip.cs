using System;
using UnityEngine;

[Obsolete("Use SpriteFlippable2D")]
public class NPCFlip //: NPCComponents
{

    //[SerializeField] private float threshold = 0.1f;

    //// Returns if our character is facing Right
    //public bool FacingRight { get; set; }

    //private void Awake()
    //{
    //    FacingRight = true;
    //}

    //protected override void HandleAbility()
    //{
    //    base.HandleAbility();
    //    FlipToMoveDirection();
    //}

    //// Flips our character by the direction we are moving
    //private void FlipToMoveDirection()
    //{
    //    if (controller.CurrentMovement.normalized.magnitude > threshold)
    //    {
    //        if (controller.CurrentMovement.normalized.x > 0)
    //        {
    //            FaceDirection(1);
    //        }
    //        else
    //        {
    //            FaceDirection(-1);
    //        }
    //    }
    //}

    //// Makes our character face the direction in which is moving
    //private void FaceDirection(int newDirection)
    //{
    //    if (newDirection == 1)
    //    {
    //        npc.NPCSprite.transform.localScale = new Vector3(1,1,1);
    //        FacingRight = true;
    //    }
    //    else
    //    {
    //        npc.NPCSprite.transform.localScale = new Vector3(-1,1,1);
    //        FacingRight = false;
    //    }
    //}
}
