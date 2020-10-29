using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDash : CharacterComponents
{
  [SerializeField] private float dashDistance = 3f; //distance it move
  [SerializeField] private float dashDuration = 0.1f; //how long for it

  private bool isDashing; //true when we change to dashing state
  private float dashTimer; //timer on the phase of dashing
  private Vector2 dashOrigin; //starting position of dashing
  private Vector2 dashDestination; //destination of dashing
  private Vector2 newPosition; //new position to move next

  protected override void HandleInput()
  {
    if (Input.GetKeyDown(KeyCode.Space)) //space bar
    {
      Dash();
    }
  }

  protected override void HandleAbility()
  {
    base.HandleAbility(); //we call the handle ability is in update() for Character component-> this this HandleAbility will override it thus result in calling this function, when we call this, the handleability in CharacterComponent will be called -> handleInput will be called next, then override by handleinput in characterdash class

    if (isDashing)
    {
      if (dashTimer < dashDuration) //move 1 seconds by 1 seconds
      {
        newPosition = Vector2.Lerp(dashOrigin, dashDestination, dashTimer / dashDuration);
        controller.MovePosition(newPosition);
        dashTimer += Time.deltaTime;
      }
      else
      {
        StopDash();
      }
    }
  }
  private void Dash() //Update destination
  {
    isDashing = true;
    dashTimer = 0f; //bcs baru start dash
    controller.NormalMovement = false;
    dashOrigin = transform.position; //current position

    dashDestination = transform.position + (Vector3)controller.CurrentMovement.normalized * dashDistance;
  }
  private void StopDash()
  {
    isDashing = false;
    controller.NormalMovement = true;
  }

}
