using UnityEngine;

public class StateController : MonoBehaviour
{
    [Header("State")]
    [SerializeField] private AIState currentState = null;
    [SerializeField] private AIState remainState = null;
    
    // Returns the target of this Enemy
    public Transform Target { get; set; }
    
    // Returns a reference to this enemy movement
    public NPC npc { get; set; }
    
    private void Awake()
    {
        npc = GetComponent<NPC>();
    }
    
    private void Update()
    {
        if (!npc.health.IsDead)
            currentState.EvaluateState(this);
    }
    
    public void TransitionToState(AIState nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }
}
