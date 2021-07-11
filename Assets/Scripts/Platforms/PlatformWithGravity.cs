using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformWithGravity : Platform
{

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.relativeVelocity.y <= 0)
        {
            Rigidbody2D rigidBody = collision.collider.GetComponent<Rigidbody2D>();

            if (rigidBody != null)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

}
