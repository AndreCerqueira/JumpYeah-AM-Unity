using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    // Global Variables
    private int tempo = 0;
    public int cloudCount;
    public int cloudMax = 15;
    public float maxX;
    [SerializeField] private GameObject[] nuvem = new GameObject[3];


    void Start()
    {
        // Get data
        maxX = GameObject.Find("maxX").transform.position.x + 2;
    }


    void Update() {
        
        // Add a cloud if one has been removed
        if (cloudCount <= cloudMax) {

            tempo = Random.Range(3, 7);
            int i = Random.Range(0, 3);

            float minY = GameObject.Find("cloudMinY").transform.position.y;
            float maxY = GameObject.Find("cloudMaxY").transform.position.y;

            Vector2 posNuvem = new Vector2(transform.position.x - 5, Random.Range(minY, maxY));
            GameObject newCloud = Instantiate(nuvem[i], posNuvem, Quaternion.identity);
            
            newCloud.transform.parent = GameObject.Find("Clouds").transform;
            cloudCount++;
        }
    }

}
