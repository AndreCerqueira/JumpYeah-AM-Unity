using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovelVerticalPlatform : Platform
{
    // Global Variables
    float yLimit;
    float initialPositionY;
    float speed;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        initialPositionY = transform.position.y;
        yLimit = Random.Range(1, 2.25f);
        speed = Random.Range(1.25f, 1.75f);

    }

    // Update is called once per frame
    protected override void Update()
    {
        if (platformDestroyer.transform.position.y > initialPositionY && platformDestroyer.transform.position.y > transform.position.y) {
            GetComponentInParent<PlatformGenerator>().destroyPlatform(gameObject);
        }
            
        transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);

        if (yLimit > 0) {
            if (transform.position.y > initialPositionY + yLimit) {
                yLimit *= -1;
                speed *= -1;
            }
        }
        else {
            if (transform.position.y < initialPositionY + yLimit) {
                yLimit *= -1;
                speed *= -1;
            }
        }

    }

}
