using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : Movable2D
{
  protected Animator animator;

  void Start()
  {
    animator = GetComponent<Animator>();
  }
}


