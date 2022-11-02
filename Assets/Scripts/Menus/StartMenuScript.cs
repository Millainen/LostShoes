using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenuScript : MonoBehaviour
{
    public static bool completedTheGame;
    public static bool speedrunMode;
    public string levelToLoad;
    public GameObject timedMode;

    private void Start()
    {
        if (completedTheGame)
            timedMode.gameObject.SetActive(true);
        else
            timedMode.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        speedrunMode = false;
        SceneManager.LoadScene(levelToLoad);
    }
    public void SpeedrunMode()
    {
        speedrunMode = true;
        SceneManager.LoadScene("levelOne");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
