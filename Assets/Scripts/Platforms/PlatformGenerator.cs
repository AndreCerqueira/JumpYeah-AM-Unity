using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platform;
    public GameObject platformMovelHorizontal;
    public GameObject platformMovelVertical;
    public GameObject platformWithGravity;
    public Vector3 spawnPosition = new Vector3(0, -5, 0);
    int platformQuantity = 20;
    int platformCount = 0;
    float levelWidth = 2.25f;
    float minY = 0.3f;
    float maxY = 1.5f;

    float scoreNeededToIncreasePlatformDistance;

    void Start() 
    {
        scoreNeededToIncreasePlatformDistance = 1000;

        for (int i = 0; i < platformQuantity; i++)
            createPlatform();
    }


    void Update() 
    {
        if (GameManager.score < 10000) 
        {
            if (GameManager.score > scoreNeededToIncreasePlatformDistance) 
            {
                scoreNeededToIncreasePlatformDistance += 1000;
                minY += 0.075f;
                maxY += 0.15f;
            }
        }

    }


    public void createPlatform() 
    {
        spawnPosition.y += Random.Range(minY, maxY);
        spawnPosition.x = Random.Range(-levelWidth, levelWidth);

        #region chances

            int randomChance = Random.Range(1, 20);
            int horizontalMovelChance = 0;
            int withGravityChance = 0;
            int verticalMovelChance = 0;
            GameObject prefab = new GameObject();

            // horizontal Movel Chance
            if (GameManager.score > 1000) {
                if (GameManager.score < 3000) {
                    horizontalMovelChance = 2;
                }
                else if (GameManager.score < 4000) {
                    horizontalMovelChance = 3;
                }
                else if (GameManager.score < 5000) {
                    horizontalMovelChance = 4;
                }
                else {
                    horizontalMovelChance = 5;
                }
            }

            // with gravity Chance
            if (GameManager.score > 3000) {
                if (GameManager.score < 5000) {
                    withGravityChance = 2;
                }
                else if (GameManager.score < 7000) {
                    withGravityChance = 3;
                }
                else if (GameManager.score < 8000) {
                    withGravityChance = 4;
                }
                else {
                    withGravityChance = 5;
                }
            }

            // vertical Movel Chance
            if (GameManager.score > 5000) {
                if (GameManager.score < 7000) {
                    verticalMovelChance = 2;
                } else {
                    verticalMovelChance = 3;
                }
            }

            if (horizontalMovelChance != 0 && randomChance < horizontalMovelChance)
                prefab = platformMovelHorizontal;
            else if (withGravityChance != 0 && (randomChance < withGravityChance + horizontalMovelChance))
                prefab = platformWithGravity;
            else if (verticalMovelChance != 0 && (randomChance < withGravityChance + horizontalMovelChance + verticalMovelChance))
                prefab = platformMovelVertical;
            else 
                prefab = platform;

        #endregion

        GameObject newPlatform = Instantiate(prefab, spawnPosition, Quaternion.identity);
        newPlatform.transform.parent = GameObject.Find("Platforms").transform;
        platformCount++;
    }


    public void destroyPlatform(GameObject platform) 
    {
        platformCount--;
        createPlatform();
        Destroy(platform);
    }
}
