using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformWithGravity : Platform
{
    // Global Variables
    [SerializeField] private Sprite[] spriteSkins;

    protected override void Start()
    {
        base.Start();

        // Get a random sprite
        GetComponent<SpriteRenderer>().sprite = spriteSkins[Random.Range(0, spriteSkins.Length)];
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        // Drop the platform after a collision
        if (collision.relativeVelocity.y <= 0)
        {
            Rigidbody2D rigidBody = collision.collider.GetComponent<Rigidbody2D>();

            if (rigidBody != null)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                GetComponent<EdgeCollider2D>().isTrigger = true;
            }
        }
    }

}
