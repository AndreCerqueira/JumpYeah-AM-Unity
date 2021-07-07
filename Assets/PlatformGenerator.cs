using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;

    public int plataformCount = 0;
    private int plataformCountMax = 30;
    private float minX, maxX;
    private float minY, maxY;

    // Start is called before the first frame update
    void Start() {

        minX = GameObject.Find("minX").transform.position.x;
        maxX = GameObject.Find("maxX").transform.position.x;
        minY = GameObject.Find("minY").transform.position.y;
        maxY = GameObject.Find("maxY").transform.position.y;

        createInitialPlatforms();

        StartCoroutine(autoCreatePlatforms());
    }


    // Update is called once per frame
    void Update() {
 
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
        GameObject newPlatform = Instantiate(platform, new Vector2(
            Random.Range(minX, maxX), 
            Random.Range(minY, maxY)), 
            Quaternion.identity
        );

        newPlatform.transform.parent = GameObject.Find("Platforms").transform;
        plataformCount++;
    } 


    IEnumerator autoCreatePlatforms() {

        while (true)
        {
            yield return new WaitForFixedUpdate();
            
            if (plataformCount <= plataformCountMax) {
                createPlatform();
            }
        }
    }


}
