using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    private int tempo = 0;
    public int cloudCount;
    private int cloudMax = 6;

    public float maxX;
    private float minY, maxY;

    [SerializeField] private GameObject[] nuvem = new GameObject[3];

    void Start()
    {
        maxX = GameObject.Find("maxX").transform.position.x + 2;
        minY = 0;
        maxY = GameObject.Find("minY").transform.position.y;
        StartCoroutine(criarNuvem());
    }


    IEnumerator criarNuvem()
    {
        while (true)
        {
            yield return new WaitForSeconds(1); // WaitForFixedUpdate();

            if (cloudCount <= cloudMax) {

                tempo = Random.Range(3, 7);
                int i = Random.Range(0, 3);

                Vector2 posNuvem = new Vector2(transform.position.x - 5, Random.Range(minY, maxY));
                GameObject newCloud = Instantiate(nuvem[i], posNuvem, Quaternion.identity);
                
                newCloud.transform.parent = GameObject.Find("Clouds").transform;
                cloudCount++;
            }

        }
    }
}
