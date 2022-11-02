using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PointCalculator.points++;
            PointSound.collectedPoint = true;
            Destroy(gameObject);
        }
    }
}
