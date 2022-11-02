using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicPlayerControl : MonoBehaviour
{
    Animator anim;
    float speed = 5f;
    public Transform target; //the place where player walks up to
    public bool inTarget;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        Time.timeScale = 1f;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        
        if (transform.position == target.position)
            inTarget = true;

        AnimateThis();
    }

    void AnimateThis()
    {
        if (!inTarget)
            anim.Play("walk");
        else
            anim.Play("empty");
    }
}
