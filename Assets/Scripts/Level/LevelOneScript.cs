using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneScript : MonoBehaviour
{
    void Awake()
    {
        GameOverScript.level = "LevelOne";
        PointCalculator.points = 0;
        Timer.secondsCount = 0f;
        Timer.minuteCount = 0;
    }
}
