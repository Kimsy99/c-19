using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [Header("State")]
    [SerializeField] private AIState currentState;
    [SerializeField] private AIState remainState;
    
    // Returns the target of this Enemy
    public Transform Target { get; set; }
    
    // Returns a reference to this enemy movement
    public NPCMovement NPCMovement { get; set; }
    
    private void Awake()
    {
        NPCMovement = GetComponent<NPCMovement>();
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
