using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingCinematicDialogue : MonoBehaviour
{
    #region initialisation
    public GameObject textBox;

    string dialog;
    public Text txt;

    bool canSkip; //whether we are in the middle of typing the text adn thus can skip it
    bool runCoroutine; //we need this so that the coroutine doesn't try to run every frame

    int i = 0; //this is used to get dialogue onwards

    public GameObject player;
    public GameObject shoeThief;
    [HideInInspector]
    public CinematicPlayerControl playerCntrl;

    public GameObject enemyFace;
    public GameObject playerFace;

    bool enemySpeaking;
    #endregion

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
            ChangeFace();
        }
    }
    void Dialogue()
    {
        switch (i) //here you can see why we need the i
        {
            case 0:
                textBox.gameObject.SetActive(true);
                dialog = "So you have stolen my shoes.";
                Coroutine();
                break;
            case 1:
                dialog = "...";
                enemySpeaking = true;
                Coroutine();
                break;
            case 2:
                dialog = "Why?";
                enemySpeaking = false;
                Coroutine();
                break;
            case 3:
                dialog = "It is quite simple, really.";
                enemySpeaking = true;
                Coroutine();
                break;
            case 4:
                dialog = "I am you from the future. And I am here to warn you.";
                Coroutine();
                break;
            case 5:
                dialog = "Red with green? Don't do it.";
                Coroutine();
                break;
            case 6:
                dialog = "But... But...";
                enemySpeaking = false;
                Coroutine();
                break;
            case 7:
                dialog = "You are purple! They don't work better with purple at all.";
                Coroutine();
                break;
            case 8:
                dialog = "I think you are trying to make fun of me. You are not me from future. You are just someone who stole my shoes.";
                Coroutine();
                break;
            case 9:
                dialog = "And I am going to get them back!";
                Coroutine();
                break;
            case 10:
                dialog = "Oh yeah? Try it!";
                enemySpeaking = true;
                Coroutine();
                break;
            case 11:
                if (!runCoroutine)
                {
                    StartCoroutine(ShoetThiefLeavesSequence());
                    runCoroutine = true;
                }
                break;
            case 12:
                dialog = "Wait? No way!";
                enemySpeaking = false;
                Coroutine();
                break;
            case 13:
                textBox.gameObject.SetActive(false);
                StartCoroutine(PlayerFollowsSequence());
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
        if (enemySpeaking)
        {
            enemyFace.gameObject.SetActive(true);
            playerFace.gameObject.SetActive(false);
        }
        else
        {
            enemyFace.gameObject.SetActive(false);
            playerFace.gameObject.SetActive(true);
        }
    }

    IEnumerator ShoetThiefLeavesSequence()
    {
        shoeThief.GetComponent<Animation>().Play("ShoethiefGoes");
        yield return new WaitForSeconds(1f);
        i++;
        runCoroutine = false;
    }
    IEnumerator PlayerFollowsSequence()
    {
        player.GetComponent<Animation>().Play("PlayerFollows");
        yield return new WaitForSeconds(.73f);
        SceneManager.LoadScene("LevelFour");
    }

    public void Skip()
    {
        SceneManager.LoadScene("LevelFour");
    }
}
