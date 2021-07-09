using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // Global Variables
    [SerializeField] private GameObject platform;
    private List<Vector2> platformPositionList = new List<Vector2>();
    public int plataformCount = 0;
    private int plataformCountMax = 30;
    private float minX, maxX;
    private float minY, maxY;


    // Start is called before the first frame update
    void Start() {

        // Set data
        minX = GameObject.Find("minX").transform.position.x;
        maxX = GameObject.Find("maxX").transform.position.x;
        minY = GameObject.Find("minY").transform.position.y;
        maxY = GameObject.Find("maxY").transform.position.y;

        createInitialPlatforms();
    }

    // Update is called once per frame
    void Update()
    {

        if (plataformCount <= plataformCountMax) {
            createPlatform();
        }
    }

    private void createInitialPlatforms() {

        minY = -5;
        maxY = GameObject.Find("minY").transform.position.y;

        for (int i = 0; i < 15; i++) {
            createPlatform();
        }

        minY = GameObject.Find("minY").transform.position.y;
        maxY = GameObject.Find("maxY").transform.position.y;
    } 


    private void createPlatform() 
    {
        Vector2 posPlatform = Vector2.zero;

        if (plataformCount > 0) {
            
            for (int i = 0; i < plataformCount; i++) {
                
                if (i == 0)
                    posPlatform = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

                while (Vector2.Distance(posPlatform, platformPositionList[i]) < 1) {
                    posPlatform = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                } 

            }
        }
        else {
            posPlatform = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }

        GameObject newPlatform = Instantiate(platform, posPlatform, Quaternion.identity);
        
        platformPositionList.Add(newPlatform.transform.position);
        newPlatform.transform.parent = GameObject.Find("Platforms").transform;
        plataformCount++;
    } 

}
