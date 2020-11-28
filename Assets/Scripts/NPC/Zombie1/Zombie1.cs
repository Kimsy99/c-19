using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1 : NPCMovement
{
  [SerializeField] private float attackRange;
  private Transform target;
  // Start is called before the first frame update
  void Start()
  {
    base.Start();
    target = GameObject.FindWithTag("Player").transform;
  }

  // Update is called once per frame
  void Update()
  {
    // base.Update();
    //player outside the range
    if (Vector2.Distance(transform.position, target.position) >= attackRange)
    {
      Patrol();
    }
    else
    {
      Debug.Log("Found player");
    }
  }
}
