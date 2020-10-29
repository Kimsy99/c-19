using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponents : MonoBehaviour
{
    //protected then inherit class can use
  protected float horizontalInput;
  protected float verticalInput;
  protected CharacterController controller; // bcs it is controlling the rigid body
  protected CharacterMovement characterMovement;
  protected Animator animator;
  protected Character character;
  // Start is called before the first frame update
  protected virtual void Start()
  {
    controller = GetComponent<CharacterController>(); //hold the character controller that hold the rigidbody for us to control the character body
    characterMovement = GetComponent<CharacterMovement>();
    character = GetComponent<Character>();
    animator = GetComponent<Animator>();
  }

  protected virtual void Update()
  {
    // Debug.Log("Update Components");
    HandleAbility();
  }

  // Main method. Here we put the logic of each ability
  protected virtual void HandleAbility()
  {
    InternalInput();
    HandleInput();
  }

  // Here we get the necessary input we need to perform our actions    
  protected virtual void HandleInput()
  {

  }

  // Here get the main input we need to control our character
  protected virtual void InternalInput()
  {
    horizontalInput = Input.GetAxisRaw("Horizontal");
    verticalInput = Input.GetAxisRaw("Vertical");
  }
}
