using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovelHorizontalPlatform : Platform
{
    // Global Variables
    float xLimit;
    float speed;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        xLimit = Random.Range(1, 2.25f);
        speed = Random.Range(1.25f, 1.75f);

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
            
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);

        if (xLimit > 0) {
            if (transform.position.x > xLimit) {
                xLimit *= -1;
                speed *= -1;
                GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
            }
        }
        else {
            if (transform.position.x < xLimit) {
                xLimit *= -1;
                speed *= -1;
                GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
            }
        }

    }

}
