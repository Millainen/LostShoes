using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public bool dead;
    public GameObject enemy;

    void Update()
    {
        if (dead)
        {
            PointCalculator.points++;
            PointSound.collectedPoint = true;
            Destroy(enemy);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerWeapon"))
        {
            dead = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerWeapon"))
        {
            dead = false;
        }
    }

}
