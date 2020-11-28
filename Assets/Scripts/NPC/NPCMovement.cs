using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : AnimatableMovable2D
{
  public Transform wayPoint01, wayPoint02;
  private Transform wayPointTarget;
  [SerializeField] protected float walkSpeed = 7;
  private readonly int movingParamater = Animator.StringToHash("Moving");
  private float vx;
  private float vy;
  protected void Start()
  {
    wayPointTarget = wayPoint01;
  }
  // Update is called once per frame
  protected void Update()
  {

  }
  protected void Patrol()
  {
    //movement
    Vector2 nextPosition = Vector2.MoveTowards(transform.position, wayPointTarget.position, walkSpeed * Time.deltaTime);
    if (Vector2.Distance(transform.position, wayPoint01.position) <= 0.01f)
    {
      wayPointTarget = wayPoint02;
    }
    if (Vector2.Distance(transform.position, wayPoint02.position) <= 0.01f)
    {
      wayPointTarget = wayPoint01;
    }
    // transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, walkSpeed * Time.deltaTime);

    //controller

    if ((transform.position.x - nextPosition.x) < -0.03f)
    {
      vx = 1;
    }
    else if ((transform.position.x - nextPosition.x) > 0.03f)
    {
      vx = -1;
    }
    else
    {
      vx = 0;
    }



    if ((transform.position.y - nextPosition.y) < -0.03f)
    {
      vy = 1;
    }
    else if ((transform.position.y - nextPosition.y) > 0.03f)
    {
      vy = -1;
    }
    else
    {
      vy = 0;
    }
    // Debug.Log(Vector2.MoveTowards(transform.position, wayPointTarget.position, walkSpeed * Time.deltaTime));


    // vx = Input.GetAxisRaw("Horizontal");
    // vy = Input.GetAxisRaw("Vertical");
    // Debug.Log(-(transform.position.x - nextPosition.x) * 10 + " " + -(transform.position.y - nextPosition.y) * 10);

    // SetVelocity(vx * walkSpeed, vy * walkSpeed);
    SetVelocity(-(transform.position.x - nextPosition.x) * 7 * walkSpeed, (-(transform.position.y - nextPosition.y) * 7) * walkSpeed);
    // UpdateAnimations();

  }
  // private void UpdateAnimations()
  // {
  //   if (Mathf.Abs(vx) > 0.1f || Mathf.Abs(vy) > 0.1f)
  //   {
  //     animator.SetBool(movingParamater, value: true);
  //   }
  //   else
  //   {
  //     animator.SetBool(movingParamater, value: false);
  //   }
  // }

}



