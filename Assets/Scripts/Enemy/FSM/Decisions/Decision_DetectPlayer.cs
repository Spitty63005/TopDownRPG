using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision_DetectPlayer : FSM_Decisions
{
    [SerializeField] float agroRange;
    [SerializeField] LayerMask playerMask;

    EnemyBrain enemy;

    private void Awake()
    {
        enemy = GetComponent<EnemyBrain>();
    }

    public override bool Decide()
    {
        print("y");
        return DetectPlayer();
    }


    bool DetectPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, playerMask, playerMask);
        print("collider " + playerCollider);
        if(playerCollider != null)
        {
            // assign player
            print("f");
            enemy.Player = playerCollider.transform;
            return true;
        }
        enemy.Player = null;
        return false;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agroRange);
    }




}
