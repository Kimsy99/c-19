using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Movable2D
{
  protected Animator animator;

  void Start()
  {
    animator = GetComponent<Animator>();
  }
}

