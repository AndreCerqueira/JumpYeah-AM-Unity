using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Global Variables
    GameObject platformDestroyer;


    // Start is called before the first frame update
    void Start()
    {
        // Get data
        platformDestroyer = GameObject.Find("platformDestroyer");
    }


    // Update is called once per frame
    void Update()
    {
        // Destroy power up
        if (platformDestroyer.transform.position.y > transform.position.y) {
            Destroy(gameObject);
        }
    }


    protected virtual void OnTriggerEnter2D(Collider2D other) 
    {
        
        if (other.CompareTag("Player")) 
        {
            if (other.GetComponent<Player>().playerState == Player.state.normal) 
            {
                Destroy(gameObject);
            }
        }
    }

}
