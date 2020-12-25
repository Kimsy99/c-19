using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Follow", fileName = "ActionFollow")]
public class ActionFollow : AIAction
{
	public float minDistanceToFollow = 2;
	public float followingSpeed = 1;
	
	public override void Act(StateController controller)
	{
		FollowTarget(controller);
	}

	private void FollowTarget(StateController controller)
	{
		if (controller.Target == null)
			return;

		// Calculate direction
		Vector2 targetDirectionVector = controller.Target.position - controller.transform.position;
		float direction = Vector2.SignedAngle(Vector2.right, targetDirectionVector);

		if (Vector2.Distance(controller.transform.position, controller.Target.position) > minDistanceToFollow)
		{
			controller.npc.movement.Direction = direction;
			controller.npc.movement.Speed = followingSpeed;
		}
		else
		{
			controller.npc.movement.Speed = 0;
			if (controller.Target.position.x > controller.transform.position.x)
				controller.npc.spriteFlippable2D.Facing = SpriteFlippable2D.RelativeDirection.Right;
			else
				controller.npc.spriteFlippable2D.Facing = SpriteFlippable2D.RelativeDirection.Left;
		}
	}
}
