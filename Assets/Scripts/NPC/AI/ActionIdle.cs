using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Idle", fileName = "ActionIdle")]
public class ActionIdle : AIAction
{
	public override void Act(StateController controller)
	{
		Debug.Log("idle");
		controller.npc.movement.Speed = 0;
	}
}
