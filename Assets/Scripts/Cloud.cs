using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Global Variables
    private CloudGenerator cloudGenerator;
    private float vel;

    // Start is called before the first frame update
    void Start()
    {
        // Get data
        cloudGenerator = GetComponentInParent<CloudGenerator>();
        vel = Random.Range(1.1f, 2.1f);
    }

    // Update is called once per frame
    void Update()
    {
        // Move forward
        transform.position = new Vector2(transform.position.x + vel * Time.deltaTime, transform.position.y);

        // Destroy cloud
        if (transform.position.x > cloudGenerator.maxX) {
            cloudGenerator.cloudCount -= 1;
            Destroy(gameObject);
        }

    }

}
