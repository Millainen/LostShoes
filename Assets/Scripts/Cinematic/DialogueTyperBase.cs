using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTyperBase : MonoBehaviour
{
    public GameObject textBox; //this is here in case the text box's visibility needs to be toggled on/off.
                               //Just drop the textbox image here in the inspector

    string dialog; //the dialogue
    public Text txt; //the text that displays the dialogue in UI

    bool canSkip; //determines if we are in the middle of typing the text and thus can skip it
    bool runCoroutine; //we need this so that the coroutine doesn't try to run every frame

    int i = 0; //this is used to get dialogue onwards with switch case

    float typingWait = 0.3f; //how much time passes between the letters typed

    void Update()
    {
        TheDialogueLogic();
        Dialogue();
    }

    void TheDialogueLogic() //advancing the dialogue and determining if we can skip it
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
    }

    void Dialogue() //the dialogue itself
    {
        switch (i) 
        {
            case 0:
                dialog = "This is a switch case statement.";
                Coroutine();
                break;
            case 1:
                dialog = "We can forward the dialogue with as many cases as we need..";
                Coroutine();
                break;
            case 2:
                dialog = "It's pretty neet.";
                Coroutine();
                break;
        }
    }

    void Coroutine() //running the coroutine
    {
        if (!runCoroutine)
        {
            StartCoroutine(Typer());
            runCoroutine = true;
        }
    }

    IEnumerator Typer() //typing the text
    {
        for (int i = 0; i < (dialog.Length + 1); i++)
        {
            canSkip = true;
            txt.text = dialog.Substring(0, i);
            yield return new WaitForSeconds(typingWait);
        }
        txt.text = dialog;
        canSkip = false;
    }
}
