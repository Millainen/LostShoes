using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoChangeToYourNewShoes : MonoBehaviour
{
    bool inTrigger;
    public GameObject goChange;
    public Text goChangeTxt;

    void Update()
    {
        if (AcquireShoes.shoesAcquired)
        {
            if (inTrigger)
            {
                goChange.gameObject.SetActive(true);
                goChangeTxt.text = "Go change to your new shoes? [Press Z]";
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    if (StartMenuScript.speedrunMode)
                        SceneManager.LoadScene("SpeedrunWin");
                    else
                        SceneManager.LoadScene("TakeTheShoes");
                }
            }
            else
                goChange.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            inTrigger = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            inTrigger = false;
    }
}
