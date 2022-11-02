using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject timer;
    public Text timerText;
    public static float secondsCount;
    public static int minuteCount;

    public static float secondsFromThePreviousLevel;
    public static int minutesFromThePreviousLevel;

    void Update()
    {
        if(StartMenuScript.speedrunMode)
            UpdateTimerUI();
        else
            timer.gameObject.SetActive(false);
    }

    void UpdateTimerUI()
    {
        secondsCount += Time.deltaTime;
        timerText.text = minuteCount + ":" + (int)secondsCount;
        if (secondsCount >= 60f)
        {
            minuteCount++;
            secondsCount = 0f;
        }
    }
}
