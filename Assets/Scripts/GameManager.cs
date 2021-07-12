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
        // Get data
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        player = GameObject.Find("Player");
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y * 100 > score)
            score = (int)(player.transform.position.y * 100);

        if (score > 7500) {

            SpriteRenderer background = GameObject.Find("sky").GetComponent<SpriteRenderer>();
            Color newColor = background.color;

            if (score > 20000)
                newColor = new Color(153/255f, 217/255f, 234/255f); 
            else if (score > 15000) 
                newColor = new Color(25/255f, 25/255f, 112/255f); 
            else
                newColor = new Color(255/255f, 190/255f, 133/255f); 

            background.color = Color.Lerp(background.color, newColor, Mathf.PingPong(Time.deltaTime, 1)); 
            
        }

        if (score > 20000) { //22500
            CloudGenerator cloudGenerator = GameObject.Find("WorldGenerator").GetComponent<CloudGenerator>();
            if (cloudGenerator.cloudMax != 100)
                cloudGenerator.cloudMax = 100;
        }

        scoreText.text = "Score: " + score;
    }

}
