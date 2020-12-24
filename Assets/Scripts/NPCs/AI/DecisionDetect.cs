using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Detect Target", fileName = "DecisionDetect")]
public class DecisionDetect : AIDecision
{
	public float detectArea = 3F;
	public LayerMask targetMask;
	
	private Collider2D targetCollider2D;
	
	public override bool Decide(StateController controller)
	{
		return CheckTarget(controller);
	}
	
	private bool CheckTarget(StateController controller)
	{
		//Debug.Log(controller.transform.position);
		targetCollider2D = Physics2D.OverlapCircle(controller.transform.position, detectArea, targetMask);
		if (targetCollider2D != null)
		{
			// Target is nearby, now we want to make sure that the NPC can actually see the target by raycasting
			Vector2 directionVector = targetCollider2D.transform.position - controller.Npc.center.position;
			RaycastHit2D hit = Physics2D.Raycast(controller.Npc.center.position, directionVector, directionVector.magnitude, LayerMask.GetMask("Wall"));
			if (!hit)
			{
				controller.Target = targetCollider2D.transform;
				return true;
			}
		}
		return false;
	}
}
