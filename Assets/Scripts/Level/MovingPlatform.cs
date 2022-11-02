using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is from the lecture on week 5
public class MovingPlatform : MonoBehaviour
{
    #region Initialisation
    [Range (3f,15f)]
    public float movementSpeed;
    public float movementAmount = 5.3f;

    float startX;
    float endX;
    bool movingRight = true;
    #endregion

    void Start()
    {
        startX = transform.position.x;
        endX = startX + movementAmount;
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (transform.position.x >= endX && movingRight)
        {
            movingRight = false;
        }
        else if (transform.position.x <= startX && !movingRight)
        {
            movingRight = true;
        }
        if (movingRight)
        {
            movementSpeed = Mathf.Abs(movementSpeed);
        }
        else
        {
            movementSpeed = -Mathf.Abs(movementSpeed);
        }
        Vector3 platformMove = new Vector3(movementSpeed, 0, 0);
        transform.Translate(platformMove * Time.deltaTime);
    }
}
