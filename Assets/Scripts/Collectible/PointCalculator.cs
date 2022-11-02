using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCalculator : MonoBehaviour
{
    public static int points;
    public static int pointsLeftFromPreviousLevel;
    public Text pointTxt;

    void Update()
    {
        pointTxt.text = "Points: " + points;
    }
}
