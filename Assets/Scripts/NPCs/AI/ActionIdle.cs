using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Idle", fileName = "ActionIdle")]
public class ActionIdle : AIAction
{
	public override void Act(StateController controller)
	{
		controller.Npc.movement.Speed = 0;
	}
}
