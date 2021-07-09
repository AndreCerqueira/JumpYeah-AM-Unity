using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{

    public float movementSpeed = 10f;

    Rigidbody2D rigidBody;
    float movement = 0f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rigidBody.velocity;
        velocity.x = movement;
        rigidBody.velocity = velocity;
    }
}
