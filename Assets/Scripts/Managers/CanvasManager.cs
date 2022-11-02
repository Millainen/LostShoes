using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Text pointsTxt;
    public Text victoryLevelTxt;

    void Start()
    {
        pointsTxt.text = "Points acquired: " + PointCalculator.points + " / 41";

        if (PointCalculator.points < 15)
            victoryLevelTxt.text = "Level: Novice";
        else if (PointCalculator.points >= 15 && PointCalculator.points < 25)
            victoryLevelTxt.text = "Level: Below Average";
        else if (PointCalculator.points >= 25 && PointCalculator.points < 35)
            victoryLevelTxt.text = "Level: Above Average";
        else if (PointCalculator.points >= 35 && PointCalculator.points < 45)
            victoryLevelTxt.text = "Level: Expert";
        else if (PointCalculator.points >= 45)
            victoryLevelTxt.text = "Level: Master";
    }

    public void BackToMainMenu()
    {
        StartMenuScript.completedTheGame = true;
        SceneManager.LoadScene("StartMenu");
    }
}
