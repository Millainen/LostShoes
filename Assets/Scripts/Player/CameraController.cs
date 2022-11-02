using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using the script from the class, slightly modified
public class CameraController : MonoBehaviour
{
    public Transform playerT;
    void Update()
    {
        if(GameOverScript.level == "LevelOne" || GameOverScript.level == "LevelFour")
        {
            Camera.main.transform.position =
                new Vector3(playerT.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
        else
        {
            Camera.main.transform.position =
                new Vector3(playerT.position.x, playerT.position.y, Camera.main.transform.position.z);
        }
    }
}
