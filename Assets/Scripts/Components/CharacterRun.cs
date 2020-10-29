using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRun : CharacterComponents
{
  // Start is called before the first frame update
  [SerializeField] private float runSpeed = 10f;
  protected override void HandleInput()
  {
    if (Input.GetKey(KeyCode.LeftShift))
    {
      Run();
    }
    if (Input.GetKeyUp(KeyCode.LeftShift)) // not pressing
    {
      StopRun();
    }
  }

  private void Run()
  {
    characterMovement.MoveSpeed = runSpeed;
  }
  private void StopRun()
  {
    characterMovement.ResetSpeed(); //then reset speed back to walk speed
  }

}
