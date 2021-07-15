using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Global Variables
    GameObject player;
    GameObject platformDestroyer;
    public float speed;
    Vector3 currentVelocity;


    void Start()
    {
        // Get data
        player = GameObject.FindWithTag("Player");
        platformDestroyer = GameObject.Find("platformDestroyer");
    }


    void Update()
    {
        // Follow the player y position with smooth
        if (player.transform.position.y > transform.position.y) 
        {
            Vector3 newPos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentVelocity, 0.3f * Time.deltaTime);
        }

        if (player.transform.position.y < transform.position.y - 5) 
        {
            StartCoroutine(GameManager.DoFadeOut(GameManager.menuGame.GetComponent<CanvasGroup>()));
            StartCoroutine(GameManager.DoFadeIn(GameManager.menuGameOver.GetComponent<CanvasGroup>()));
            GameManager.saveRecord();
        }
    }
}
