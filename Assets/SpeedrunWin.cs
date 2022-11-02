using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpeedrunWin : MonoBehaviour
{
    public static bool completedTheSpeedrunOnce;
    public static int bestTimeMinutes;
    public static float bestTimeSeconds;

    public Text timeTxt;
    public Text pointsTxt;

    public Text bestTime;

    void Start()
    {
        timeTxt.text = "Time: " + Timer.minuteCount + ":" + (int)Timer.secondsCount;
        pointsTxt.text = "Points: " + PointCalculator.points;

        if (!completedTheSpeedrunOnce)
        {
            bestTimeMinutes = Timer.minuteCount;
            bestTimeSeconds = Timer.secondsCount;
            completedTheSpeedrunOnce = true;
        }
        else
        {
            if(bestTimeMinutes > Timer.minuteCount || bestTimeMinutes == Timer.minuteCount && bestTimeSeconds > Timer.secondsCount)
            {
                bestTimeMinutes = Timer.minuteCount;
                bestTimeSeconds = Timer.secondsCount;
            }
        }
        bestTime.text = "Best time: " + bestTimeMinutes + ":" + (int)bestTimeSeconds;
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void TryAgain()
    {
        SceneManager.LoadScene("LevelOne");
    }
}
