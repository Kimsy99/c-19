using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Detect Target Boss", fileName = "DecisionDetectBoss")]
public class DecisionDetectBoss : DecisionDetect
{
  public override bool Decide(StateController controller)
  {
    if (LevelManager.Instance.IsBossReady)
      return base.Decide(controller);
    return false;
  }
}
