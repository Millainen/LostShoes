using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFourScript : MonoBehaviour
{
    void Awake()
    {
        AcquireShoes.shoesAcquired = false;
        PointCalculator.points = PointCalculator.pointsLeftFromPreviousLevel;
        GameOverScript.level = "LevelFour";
    }
}
