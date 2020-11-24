using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie4 : Movable2D
{
  protected Animator animator;

  void Start()
  {
    animator = GetComponent<Animator>();
  }
}
