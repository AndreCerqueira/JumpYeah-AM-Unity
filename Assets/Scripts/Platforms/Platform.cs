using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Variables
    public float jumpForce = 10f;
    GameObject camara;
    protected GameObject platformDestroyer;


    // Start is called before the first frame update
    protected virtual void Start() 
    {
        // Get data
        camara = GameObject.FindWithTag("MainCamera");
        platformDestroyer = GameObject.Find("platformDestroyer");
    }


    protected virtual void Update() 
    {
        // Destroy platform
        if (platformDestroyer.transform.position.y > transform.position.y) {
            GetComponentInParent<PlatformGenerator>().destroyPlatform(gameObject);
        }
    }


    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // Add jump force to the player
        if (collision.relativeVelocity.y <= 0)
        {
            Rigidbody2D rigidBody = collision.collider.GetComponent<Rigidbody2D>();

            if (rigidBody != null)
            {
                Vector2 velocity = rigidBody.velocity;

                velocity.y = jumpForce;
                rigidBody.velocity = velocity;
            }
        }

    }

}
