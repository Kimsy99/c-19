using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Idle", fileName = "ActionIdle")]
public class ActionIdle : AIAction
{
    public override void Act(StateController controller)
    {
        controller.NPCMovement.SetHorizontal(0);
        controller.NPCMovement.SetVertical(0);
    }
}
