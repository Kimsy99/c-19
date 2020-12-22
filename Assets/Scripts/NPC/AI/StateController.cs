using UnityEngine;

public class StateController : MonoBehaviour
{
	[Header("State")]
	[SerializeField] private AIState currentState = null;
	[SerializeField] private AIState remainState = null;
	
	// Returns the target of this Enemy
	public Transform Target { get; set; }
	
	// Returns a reference to this enemy movement
	public NPC Npc { get; set; }
	
	void Awake()
	{
		Npc = GetComponent<NPC>();
	}
	
	void Update()
	{
		if (!Npc.health.IsDead)
			currentState.EvaluateState(this);
	}
	
	public void TransitionToState(AIState nextState)
	{
		if (nextState != remainState)
		{
			foreach (AITransition transition in nextState.Transitions)
				transition.Decision.Reset();
			currentState = nextState;
		}
	}
}
