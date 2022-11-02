using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreeScript : MonoBehaviour
{
    void Awake()
    {
        PointCalculator.points = PointCalculator.pointsLeftFromPreviousLevel;
        GameOverScript.level = "LevelThree";
    }
}
