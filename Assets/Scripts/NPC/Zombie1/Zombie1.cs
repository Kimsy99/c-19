using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1 : NPCMovement
{
  [SerializeField] private float attackRange;
  private Transform target;

  private readonly int isAttack = Animator.StringToHash("isAttack");
  [SerializeField] private GameObject projectile; //projectile Object
  // Start is called before the first frame update
  void Start()
  {
    base.Start();
    target = GameObject.FindWithTag("Player").transform;
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    base.Update();
    //player outside the range
    if (Vector2.Distance(transform.position, target.position) >= attackRange)
    {
      Debug.Log("No player");
      animator.SetBool(isAttack, value: false);
      // Patrol(attackRange);
    }
    else
    {
      animator.SetBool(isAttack, value: true);
      // Shot();
      Debug.Log("Found player");

    }
    Patrol(attackRange);
    //test minus life point
    if (Input.GetKeyDown(KeyCode.Space))
    {
      GetComponentInChildren<NPCHealthBar>().hp -= 25;
    }
  }
  public void Shot()
  {
    Instantiate(projectile, transform.position, Quaternion.identity);
  }
}
