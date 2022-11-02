using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeThief : MonoBehaviour
{
    bool spotted;
    public GameObject portal;
    float speed = 5f;
    public GameObject trigger;

    void Update()
    {
        if (spotted)
        {
            Destroy(trigger);
            transform.position = Vector2.MoveTowards(transform.position, portal.transform.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spotted = true;
        }
    }
}
