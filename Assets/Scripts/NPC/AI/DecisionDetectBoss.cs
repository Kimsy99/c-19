using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Detect Target", fileName = "DecisionDetectBoss")]
public class DecisionDetectBoss : DecisionDetect
{
  private Collider2D targetCollider2D;

  public override bool Decide(StateController controller)
  {
    if (LevelManager.Instance.IsBossReady)
      return base.Decide(controller);
    return false;
  }

}
