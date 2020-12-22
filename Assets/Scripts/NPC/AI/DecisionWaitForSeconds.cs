using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Wait for Seconds", fileName = "DecisionWaitForSeconds")]
public class DecisionWaitForSeconds : AIDecision
{
	public float secondsToWait;
	private float timeElapsed = 0;

	public override bool Decide(StateController controller)
	{
		timeElapsed += Time.deltaTime;
		return timeElapsed > secondsToWait;
	}

	public override void Reset()
	{
		timeElapsed = 0;
	}
}
