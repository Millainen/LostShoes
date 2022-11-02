using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSound : MonoBehaviour
{
    public GameObject pointSound;
    public GameObject bulletSound;
    public GameObject jumpSound;

    public static bool collectedPoint;
    public static bool firedBullet;
    public static bool jumped;

    void Update()
    {
        if (collectedPoint)
        {
            StartCoroutine(CollectPoint());
        }
        if (firedBullet)
        {
            StartCoroutine(FireBullet());
        }
        if (jumped)
        {
            StartCoroutine(Jump());
        }
    }

    IEnumerator CollectPoint() {
        pointSound.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        pointSound.gameObject.SetActive(false);
        collectedPoint = false;
        StopAllCoroutines();
    }
    IEnumerator FireBullet()
    {
        bulletSound.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        bulletSound.gameObject.SetActive(false);
        firedBullet = false;
        StopAllCoroutines();
    }
    IEnumerator Jump()
    {
        jumpSound.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        jumpSound.gameObject.SetActive(false);
        jumped = false;
        StopAllCoroutines();
    }
}
