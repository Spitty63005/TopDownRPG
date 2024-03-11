using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    readonly int gotKilled = Animator.StringToHash("gotKilled");
    readonly int moveX = Animator.StringToHash("moveX");
    readonly int moveY = Animator.StringToHash("moveY");
    readonly int isMoving = Animator.StringToHash("isMoving");

    Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void HandleMoveBoolAnimation(bool value)
    {
        anim.SetBool(isMoving, value);
    }

    public void HandingMovingAnimation(Vector2 dir)
    {
        anim.SetFloat(moveX, dir.x);
        anim.SetFloat(moveY, dir.y);
    }

    public void HandleDeadTrigger()
    {
        anim.SetTrigger(gotKilled);
    }

}
