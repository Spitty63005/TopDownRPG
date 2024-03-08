using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class PLayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 movementDirection;

    readonly int moveX = Animator.StringToHash("moveX");
    readonly int moveY = Animator.StringToHash("moveY");
    readonly int isMoving = Animator.StringToHash("isMoving");

    Animator anim;
    Rigidbody2D rb;
    PlayerActions actions;
    

    private void Awake()
    {
        actions = new PlayerActions();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void ReadMovment()
    {
        movementDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
        if (movementDirection == Vector2.zero )
        {
            anim.SetBool(isMoving, false);
            return;
        }
        anim.SetBool(isMoving, true);
        anim.SetFloat(moveX, movementDirection.x);
        anim.SetFloat(moveY, movementDirection.y);

    }

    private void Update()
    {
        ReadMovment();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.MovePosition(rb.position + movementDirection * (moveSpeed * Time.deltaTime));
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
