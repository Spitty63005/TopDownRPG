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
    PlayerData playerData;

    private void Awake()
    {
        actions = new PlayerActions();
        animations = GetComponent<PlayerAnimations>();
        rb = GetComponent<Rigidbody2D>();
        playerData = GetComponent<PlayerData>();
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
        animations.HandlingMovingAnimation(movementDirection);


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
        if (playerData.PlayerStats.CurrentHealth <= 0)
            return;
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
