using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
        StartCoroutine(LifeSpan());
    }

    IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(30);
        Destroy(this.gameObject);
    }
}
