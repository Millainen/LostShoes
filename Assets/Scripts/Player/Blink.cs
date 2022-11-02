using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//not working quite as expected
public class Blink : MonoBehaviour
{
    private Animator anim;

    private float timer;

    bool loop;

    void Awake()
    {
        anim = GetComponent<Animator>();
        loop = true;
    }

    void Update()
    {
        timer = Random.Range(5f,30f);
        StartCoroutine(Blinking());
    }

    IEnumerator Blinking()
    {
        while (loop)
        {
            yield return new WaitForSeconds(timer);
            anim.Play("blink");
            yield return new WaitForSeconds(.5f);
            anim.Play("empty");
        }
    }
}
