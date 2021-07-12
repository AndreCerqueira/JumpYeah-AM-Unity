using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Global Variables
    float xLimit;
    float speed;
    GameObject platformDestroyer;

    // Start is called before the first frame update
    void Start()
    {
        // Get data
        xLimit = Random.Range(0.5f, 1.75f);
        speed = Random.Range(1f, 1.5f);
        platformDestroyer = GameObject.Find("platformDestroyer");
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy monster
        if (platformDestroyer.transform.position.y > transform.position.y) {
            Destroy(gameObject);
        }

        // Move monster
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);

        // Invert monster direction
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

    // Kill the player after collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true) {
            other.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }


}
