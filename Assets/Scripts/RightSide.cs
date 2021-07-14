using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSide : MonoBehaviour
{
    [SerializeField]
    private Transform minX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(minX.position.x, collision.gameObject.transform.position.y, -.5f);
        }
    }

}
