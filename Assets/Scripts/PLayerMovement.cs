using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 movementDirection;
    [SerializeField] Rigidbody2D rb;

    PlayerActions actions;
    

    private void Awake()
    {
        actions = new PlayerActions();
        rb = GetComponent<Rigidbody2D>();
    }

    void ReadMovment()
    {
        movementDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
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
