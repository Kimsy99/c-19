using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "AI/Actions/BossAttack", fileName = "BossActionAttack")]
public class BossActionAttack : AIAction
{
  public float secondsBetweenAttack;
  private float attackDelay;

  public override void Act(StateController controller)
  {
    Attack(controller);
  }

  private void Attack(StateController controller)
  {
    if (controller.Target == null)
      return;

    attackDelay = Mathf.Max(attackDelay - Time.deltaTime, 0);
    if (attackDelay == 0)
    {
      controller.Npc.heldWeapon.Shoot();
      attackDelay = secondsBetweenAttack;
    }
  }
}
