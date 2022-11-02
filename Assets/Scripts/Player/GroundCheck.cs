using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool onGround;
    public GameObject thePlayer;

    void OnCollisionEnter2D(Collision2D collider)
    {  //COLLISION ????
        if (collider.gameObject.tag == "Ground")
            onGround = true;
        else if (collider.gameObject.tag == "MovingPlatform") // used this: https://www.youtube.com/watch?v=zNXam6GGHmI for help
        {
            thePlayer.transform.parent = collider.gameObject.transform;
            onGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground")
            onGround = false;
        else if (collider.gameObject.tag == "MovingPlatform")
        {
            thePlayer.transform.parent = null;
            onGround = false;
        }
    }
}
