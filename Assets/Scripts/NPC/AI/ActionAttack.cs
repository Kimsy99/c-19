using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Attack", fileName = "ActionAttack")]
public class ActionAttack : AIAction
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
			controller.npc.heldWeapon.Shoot();
			attackDelay = secondsBetweenAttack;
		}
	}
}
