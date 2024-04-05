using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    NONE, WANDER, PATROL, CHASE, ATTACK
}

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] EnemyState enemyState;
    [SerializeField] FSM_State[] states;

    public FSM_State CurrentState { get; private set; }

    public Transform Player {  get; set; }

    void Update()
    {
        if(CurrentState == null) 
            return;

        CurrentState.UpdateState(this);
    }

    FSM_State GetState(EnemyState CurrentState)
    {
        for (int i = 0; i < states.Length; i++)
        {
            if (states[i].ID == CurrentState)
                return states[i];
        }
        return null;
    }

    public void ChangeState(EnemyState newState)
    {
        FSM_State state = GetState(newState);
        if(state == null) { return; }

        CurrentState = state;
    }
}
