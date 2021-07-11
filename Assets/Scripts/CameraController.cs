using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Variables
    GameObject player;
    GameObject platformDestroyer;
    public float speed;

    Vector3 currentVelocity;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        platformDestroyer = GameObject.Find("platformDestroyer");
    }


    void Update()
    {

        if (player.transform.position.y > transform.position.y) 
        {
            Vector3 newPos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentVelocity, 0.3f * Time.deltaTime);
        }

    }
}
