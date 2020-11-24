using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Movement : Boss3
{
  [SerializeField] private float walkSpeed = 7;
  private readonly int movingParamater = Animator.StringToHash("Moving");
  private float vx;
  private float vy;
  // Update is called once per frame
  void Update()
  {
    vx = Input.GetAxisRaw("Horizontal");
    vy = Input.GetAxisRaw("Vertical");

    float speed = walkSpeed;

    SetVelocity(vx * speed, vy * speed);
    UpdateAnimations();
  }
  private void UpdateAnimations()
  {
    if (Mathf.Abs(vx) > 0.1f || Mathf.Abs(vy) > 0.1f)
    {
      animator.SetBool(movingParamater, value: true);
    }
    else
    {
      animator.SetBool(movingParamater, value: false);
    }
  }

}

