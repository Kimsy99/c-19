using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/BossFollow", fileName = "BossActionFollow")]

public class BossActionFollow : AIAction
{
	public float minDistanceToFollow = 0;
	public float followingSpeed1;
	public float followingSpeed2;
	public float followingSpeed;
	private void Start()
	{
		followingSpeed = followingSpeed1;
	}
	public override void Act(StateController controller)
	{
		FollowTarget(controller);
	}

	private void FollowTarget(StateController controller)
	{
		if (controller.Target == null)
			return;

		if (controller.Npc.health.Hp <= controller.Npc.health.maxHp / 2)
		{
			//Debug.Log("Increase speed");
			followingSpeed = followingSpeed2;
		}
		// Debug.Log(controller.Npc.health.Hp);
		// Debug.Log(controller.Npc.health.maxHp);
		// Debug.Log("cont");
		// Calculate direction
		Vector2 targetDirectionVector = controller.Target.position - controller.transform.position;
		float direction = Vector2.SignedAngle(Vector2.right, targetDirectionVector);

		if (Vector2.Distance(controller.transform.position, controller.Target.position) > minDistanceToFollow)
		{
			controller.Npc.movement.Direction = direction;
			controller.Npc.movement.Speed = followingSpeed;
		}
		else
		{
			controller.Npc.movement.Speed = 0;
			if (controller.Target.position.x > controller.transform.position.x)
				controller.Npc.spriteFlippable2D.Facing = SpriteFlippable2D.RelativeDirection.Right;
			else
				controller.Npc.spriteFlippable2D.Facing = SpriteFlippable2D.RelativeDirection.Left;
		}
	}
}
