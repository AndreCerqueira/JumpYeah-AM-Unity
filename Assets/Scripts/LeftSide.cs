using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSide : MonoBehaviour
{
    [SerializeField]
    private Transform maxX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(maxX.position.x, collision.gameObject.transform.position.y, -.5f);
        }
    }
}
