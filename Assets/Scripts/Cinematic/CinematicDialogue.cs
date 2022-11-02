using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CinematicDialogue : MonoBehaviour
{
    public GameObject textBox;

    string dialog;
    public Text txt;

    bool canSkip; //whether we are in the middle of typing the text adn thus can skip it
    bool runCoroutine; //we need this so that the coroutine doesn't try to run every frame

    int i = 0; //this is used to get dialogue onwards

    public GameObject player;
    [HideInInspector]
    public CinematicPlayerControl playerCntrl;

    public GameObject sadFace; // this is the face in the UI
    public GameObject happyFace;

    public GameObject sadInGame; // this is the avatar's face
    public GameObject happyInGame;

    void Start()
    {
        textBox.gameObject.SetActive(false);
        playerCntrl = player.GetComponent<CinematicPlayerControl>();   
    }

    void Update()
    {
        if (playerCntrl.inTarget)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!canSkip)
                {
                    i++;
                    runCoroutine = false;
                }
                else
                {
                    StopAllCoroutines();
                    txt.text = dialog;
                    canSkip = false;
                }
            }
            Dialogue();
        }
    }

    void Dialogue()
    {
        switch (i) //here you can see why we need the i
        {
            case 0:
                textBox.gameObject.SetActive(true);
                dialog = "What a lovely day to use my new red shoes.";
                Coroutine();
                break;
            case 1:
                dialog = "I bought them yesterday and am so ready for them.";
                Coroutine();
                break;
            case 2:
                ChangeFace();
                dialog = "What is this? I cannot find them.";
                Coroutine();
                break;
            case 3:
                dialog = "Oh no, someone must have taken them. Everyone out there is crazy anyway.";
                Coroutine();
                break;
            case 4:
                dialog = "I never go outside anyway... but I guess I have to. This once.";
                Coroutine();
                break;
            case 5:
                dialog = "Here goes...";
                Coroutine();
                break;
            case 6:
                SceneManager.LoadScene("LevelOne");
                break;
        }
    }

    void Coroutine()
    {
        if (!runCoroutine)
        {
            StartCoroutine(Typer());
            runCoroutine = true;
        }
    }

    IEnumerator Typer()
    {
        for (int i = 0; i < (dialog.Length + 1); i++)
        {
            canSkip = true;
            txt.text = dialog.Substring(0, i);
            yield return new WaitForSeconds(.03f);
        }
        txt.text = dialog;
        canSkip = false;
    }

    void ChangeFace() 
    {
        sadFace.gameObject.SetActive(true);
        happyFace.gameObject.SetActive(false);
        sadInGame.gameObject.SetActive(true);
        happyInGame.gameObject.SetActive(false);
    }

    public void Skip()
    {
        SceneManager.LoadScene("LevelOne"); //TODO: SceneManager
    }
}
