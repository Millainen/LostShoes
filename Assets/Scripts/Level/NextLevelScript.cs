using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    public string levelToLoad;
    public string levelToLoadInSpeedrunMode;

    void OnTriggerEnter2D(Collider2D other)
    {
        PointCalculator.pointsLeftFromPreviousLevel = PointCalculator.points;

        Timer.secondsFromThePreviousLevel = Timer.secondsCount;
        Timer.minutesFromThePreviousLevel = Timer.minuteCount;

        if (other.CompareTag("Player"))
        {
            WeaponManager.bulletsInScene = 0;
            if (!StartMenuScript.speedrunMode)
                SceneManager.LoadScene(levelToLoad);
            else
                SceneManager.LoadScene(levelToLoadInSpeedrunMode);
        }
        if (other.CompareTag("ShoeThief"))
        {
            Destroy(other.gameObject);
        }
    }
}
