using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 movementDirection;

    Rigidbody2D rb;
    PlayerActions actions;
    PlayerAnimations animations;


    private void Awake()
    {
        actions = new PlayerActions();
        animations = new PlayerAnimations();
        rb = GetComponent<Rigidbody2D>();
    }

    void ReadMovment()
    {
        movementDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
        if (movementDirection == Vector2.zero)
        {

            animations.HandleMoveBoolAnimation(false);
            return;
        }
        animations.HandleMoveBoolAnimation(true);
        animations.HandingMovingAnimation(movementDirection);


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
