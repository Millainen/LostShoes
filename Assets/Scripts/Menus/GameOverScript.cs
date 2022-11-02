using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public static string level;

    public void TryAgain()
    {
        Timer.secondsCount = Timer.secondsFromThePreviousLevel;
        Timer.minuteCount = Timer.minutesFromThePreviousLevel;

        SceneManager.LoadScene(level);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
