using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFallTrigger : MonoBehaviour
{
    bool playerDead;
    bool hittedTheEnemy;
    bool hittedTheBullet;

    void Update()
    {
        if (playerDead)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerDead = true;
        else if (other.CompareTag("Enemy"))
        {
            PointCalculator.points++;
            PointSound.collectedPoint = true;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
