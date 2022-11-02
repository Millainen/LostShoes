using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsItPaused();
        }
        ManagePause();
    }

    public void ActivatePauseScreen()
    {
        IsItPaused();
    }

    public void ResumeGame()
    {
        isPaused = false;
    }
    public void BackToMainMenu()
    {
        isPaused = false;
        SceneManager.LoadScene("StartMenu"); //TODO: muuta nää tekee scenemanagerin kanssa yhteistyötä
    }

    void IsItPaused()
    {
        if (!isPaused)
            isPaused = true;
        else
            isPaused = false;
    }

    void ManagePause()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
