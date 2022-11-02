using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    #region variables
    bool enemyNotices; //activates when player walks close enough
    float speed = 3f;
    public Transform playerCharacter;

    float hurtForce = 8f;

    Rigidbody2D rb;

    private Vector2 target; //this is just easier to type than playerCharacter.transform.position
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        target = playerCharacter.transform.position;
        if (enemyNotices) //enemy starts moving towards player when player comes close enough
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void MoveLeftToThePlayer()
    {
        if(rb != null)
            rb.velocity = new Vector2(hurtForce, rb.velocity.y);
    }
    public void MoveRightToThePlayer()
    {
        if (rb != null)
            rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            enemyNotices = true;
    }
}
