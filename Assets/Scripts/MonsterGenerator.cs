using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    // Global Variables
    public GameObject consoleMonster;
    public GameObject pillowMonster;
    public float lastPositionY;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(monsterSpawn());
    }


    // Spawn monster after random seconds and if the player is not afk
    IEnumerator monsterSpawn() 
    {
        int seconds = 15;
        while (true)
        {
            yield return new WaitForSeconds(seconds);
            seconds = Random.Range(1, 10);

            if (GameManager.score > 5000) {
    
                int chance = Random.Range(1,3);
                if (chance == 1) 
                {
                    Vector3 spawnPosition = GetComponent<PlatformGenerator>().spawnPosition;
                    if (spawnPosition.y > lastPositionY + 1) {

                        int monsterID = Random.Range(1,3);
                        GameObject monster = (monsterID == 1) ? consoleMonster : pillowMonster;
                        
                        GameObject newMonster = Instantiate(monster, spawnPosition, Quaternion.identity);
                        newMonster.transform.parent = GameObject.Find("Monsters").transform;
                        lastPositionY = spawnPosition.y;
                    }
                }
            }
        }

    }

}
