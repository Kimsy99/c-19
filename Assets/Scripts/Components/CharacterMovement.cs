using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : CharacterComponents
{
  [SerializeField] private float walkSpeed = 6f; //walk speed of component

  // A property is a method to store / return a value. In this case, its to controls our current move speed
  public float MoveSpeed { get; set; }
  // Internal
  private readonly int movingParamater = Animator.StringToHash("Moving");

  protected override void Start()
  {
    base.Start();
    MoveSpeed = walkSpeed; //set intro the variable
  }

  protected override void HandleAbility()
  {
    base.HandleAbility(); //if we have the input then we call Movecharacter()
    MoveCharacter();
    UpdateAnimation();
  }

  // Moves our character by our current speed
  private void MoveCharacter()
  {
    Vector2 movement = new Vector2(x: horizontalInput, y: verticalInput);
    // Debug.Log("movement2: " + movement2); //value could be range 1 to -1
    // Debug.Log("movement: " + movement); //value 1/-1
    //If we move in diagonally, e.g pressing A & W together, same 1 unit has been moved
    Vector2 movementNormalized = movement.normalized;
    // Debug.Log(movement + "    " + movementNormalized);
    // Debug.Log(movement);
    Vector2 movementSpeed = movementNormalized * MoveSpeed;
    // Debug.Log(movementSpeed);
    controller.SetMovement(movementSpeed); //set the Charactercontroller in the characterController there
  }

  //updates our idle and  move animation
  private void UpdateAnimation()
  {
    if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
    {
      animator.SetBool(movingParamater, value: true);
    }
    else
    {
      animator.SetBool(movingParamater, value: false);
    }
  }
  // Resets our speed from the run speed to the walk speed
  public void ResetSpeed()
  {
    MoveSpeed = walkSpeed;
  }

}
