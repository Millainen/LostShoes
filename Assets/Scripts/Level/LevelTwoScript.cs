using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoScript : MonoBehaviour
{
    void Awake()
    {
        GameOverScript.level = "LevelTwo";
        PointCalculator.points = PointCalculator.pointsLeftFromPreviousLevel;
    }
}
