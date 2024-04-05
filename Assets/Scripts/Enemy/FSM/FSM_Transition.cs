using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FSM_Transition
{
    public FSM_Decisions Decision;
    public EnemyState TrueState;
    public EnemyState falseState;

}
