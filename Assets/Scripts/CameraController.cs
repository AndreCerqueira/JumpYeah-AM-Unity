using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Variables
    GameObject player;
    
    void Start()
    {

        player = GameObject.FindWithTag("Player");
    }


    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y, -10);
    }
}
