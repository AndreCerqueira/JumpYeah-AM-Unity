using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Global Variables
    [SerializeField] private Canvas canvas;
    private Text scoreText;
    private GameObject player;

    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        player = GameObject.Find("Player");
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y * 100 > score)
            score = (int)(player.transform.position.y * 100);

        scoreText.text = "Score: " + score;
    }

}
