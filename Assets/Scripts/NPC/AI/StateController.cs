using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [Header("State")]
    [SerializeField] private AIState currentState = null;
    [SerializeField] private AIState remainState = null;
    
    // Returns the target of this Enemy
    public Transform Target { get; set; }
    
    // Returns a reference to this enemy movement
    public NPCMovementAI NPCMovementAI { get; set; }
    
    private void Awake()
    {
        NPCMovementAI = GetComponent<NPCMovementAI>();
    }
    
    private void Update()
    {
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
