using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    // Enum
    public enum state{
        normal,
        energetico,
        cafe,
    }

    // Global Variables
    public float movementSpeed = 10f;
    Rigidbody2D rigidBody;
    float movement = 0f;
    public state playerState = state.normal;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
    
        if (Input.GetAxis("Horizontal") < 0) 
            GetComponent<SpriteRenderer>().flipX = true;
        else if (Input.GetAxis("Horizontal") > 0) 
            GetComponent<SpriteRenderer>().flipX = false;    

    }

    private void FixedUpdate()
    {
        Vector2 velocity = rigidBody.velocity;
        velocity.x = movement;
        rigidBody.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            if (other.CompareTag("Platform")) {
                GetComponent<Animator>().SetTrigger("Jump");
            }
        }
    }


    public IEnumerator resetState() 
    {
        while (playerState != state.normal)
        {
            int seconds = (playerState == state.energetico) ? 3 : 5;

            yield return new WaitForSeconds(seconds);

            playerState = state.normal;
        }
    }

    public IEnumerator flyState() 
    {
        Vector2 velocity = rigidBody.velocity;
                velocity.y = 8;
                rigidBody.velocity = velocity;
        rigidBody.bodyType = RigidbodyType2D.Kinematic;

        while (playerState == state.energetico)
        {
            yield return new WaitForFixedUpdate();
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.05f);
        }

        rigidBody.bodyType = RigidbodyType2D.Dynamic;
    }

}
