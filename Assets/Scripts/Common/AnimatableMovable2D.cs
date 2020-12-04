﻿using UnityEngine;

/// <summary>
/// AnimatableMovable2Ds are an extension to Movable2Ds in that they contain animations and have an Animator component.
/// </summary>
public class AnimatableMovable2D : Movable2D
{
  protected Animator animator;
  protected readonly int movingParamater = Animator.StringToHash("Moving");

  void Start()
  {
    animator = GetComponent<Animator>();
  }

  void Update()
  {
    if (Speed > 0)
      animator.SetBool(movingParamater, value: true);
    else
      animator.SetBool(movingParamater, value: false);
  }
}
