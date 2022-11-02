using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class talkToTheThief : MonoBehaviour
{
    bool talkable;
    public static bool talkMode;
    bool dialogueExhausted;
    
    public GameObject pressToTalk;
    
    public GameObject textBox;
    string dialog;
    public Text txt;

    bool canSkip; //whether we are in the middle of typing the text adn thus can skip it
    bool runCoroutine; //we need this so that the coroutine doesn't try to run every frame

    int i = 0; //this is used to get dialogue onwards

    public GameObject enemyFace;
    public GameObject playerFace;

    bool enemySpeaking;

    public GameObject giveShoes;
    public Text giveShoesTxt;

    void Update()
    {
        if (talkable && !dialogueExhausted && !AcquireShoes.shoesAcquired)
        {
            pressToTalk.gameObject.SetActive(true);

            if (Input.GetKey(KeyCode.Z))
            {
                talkMode = true;
            }
        }
        else
            pressToTalk.gameObject.SetActive(false);

        if (AcquireShoes.shoesAcquired && talkable)
        {
            giveShoes.gameObject.SetActive(true);
            giveShoesTxt.text = "Give the shoes to them? [Press Z]";
            if (Input.GetKeyDown(KeyCode.Z)) {
                if (StartMenuScript.speedrunMode)
                    SceneManager.LoadScene("SpeedrunWin");
                else
                    SceneManager.LoadScene("GiveTheShoes");
            }
        }
        else
            giveShoes.gameObject.SetActive(false);

        if (talkMode)
            TalkMode();
    }

    void TalkMode()
    {
        textBox.gameObject.SetActive(true);
        pressToTalk.gameObject.SetActive(false);

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

    void Dialogue()
    {
        switch (i)
        {
            case 0:
                dialog = "Wait. Where are my shoes?";
                Coroutine();
                break;
            case 1:
                dialog = "...";
                enemySpeaking = true;
                Coroutine();
                break;
            case 2:
                dialog = "I lost them.";
                Coroutine();
                break;
            case 3:
                dialog = "You WHAT?";
                enemySpeaking = false;
                Coroutine();
                break;
            case 4:
                dialog = "I lost them, okay?";
                enemySpeaking = true;
                Coroutine();
                break;
            case 5:
                dialog = "Not everyone can be as brave and fearless as you.";
                Coroutine();
                break;
            case 6:
                dialog = "Brave and fearless are the same thing...";
                enemySpeaking = false;
                Coroutine();
                break;
            case 7:
                dialog = "Don't patronize me!";
                enemySpeaking = true;
                Coroutine();
                break;
            case 8:
                dialog = "Okay. Let me get this straight. So crazy outside people -- or boxes, I don't know the difference -- " +
                    "attacked you and you felt the need to run away. You kicked the shoes off so you could run faster. Is that right?";
                enemySpeaking = false;
                Coroutine();
                break;
            case 9:
                dialog = "That is right.";
                enemySpeaking = true;
                Coroutine();
                break;
            case 10:
                dialog = "In which general direction did you throw the shoes?";
                enemySpeaking = false;
                Coroutine();
                break;
            case 11:
                dialog = "Left. I think. But I think the people took the shoes even lefter.";
                enemySpeaking = true;
                Coroutine();
                break;
            case 12:
                dialog = "Your left or mine?";
                enemySpeaking = false;
                Coroutine();
                break;
            case 13:
                dialog = "I don't know. We don't really have lefts. We are boxes.";
                enemySpeaking = true;
                Coroutine();
                break;
            case 14:
                dialog = "...";
                enemySpeaking = false;
                Coroutine();
                break;
            case 15:
                dialog = "...";
                enemySpeaking = true;
                Coroutine();
                break;
            case 16:
                dialog = "Out of curiosity... why did you steal my shoes?";
                enemySpeaking = false;
                Coroutine();
                break;
            case 17:
                dialog = "Well...";
                enemySpeaking = true;
                Coroutine();
                break;
            case 18:
                dialog = "With the world going crazy and all, I wanted a little razzle dazzle in my life.";
                Coroutine();
                break;
            case 19:
                dialog = "That is quite understandable.";
                enemySpeaking = false;
                Coroutine();
                break;
            case 20:
                dialog = "Well... I guess I'm off to fetch the shoes.";
                Coroutine();
                break;
            case 21:
                dialog = "Okay... don't die!";
                enemySpeaking = true;
                Coroutine();
                break;
            case 22:
                dialog = "Don't worry, friend... if I do, I can always try again.";
                enemySpeaking = false;
                Coroutine();
                break;
            case 23:
                dialog = "...You are so brave!";
                enemySpeaking = true;
                Coroutine();
                break;
            case 24:
                dialogueExhausted = true;
                textBox.gameObject.SetActive(false);
                talkMode = false;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
            talkable = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            talkable = false;
    }
}
