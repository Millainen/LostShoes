using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcquireShoes : MonoBehaviour
{
    public static bool shoesAcquired;
    public static bool acquiringShoes;
    public GameObject shoesSign;
    public GameObject shoesInUI;

    public GameObject happyFace;
    public GameObject sadFace;

    public GameObject winSound;

    public GameObject musicPlayer;

    void Update()
    {
        if (shoesAcquired)
        {
            if (StartMenuScript.speedrunMode)
            {
                shoesInUI.gameObject.SetActive(true);
                sadFace.gameObject.SetActive(false);
                happyFace.gameObject.SetActive(true);
                gameObject.SetActive(false);
            }
            else
                StartCoroutine(ShoesAcquiringSequence());
        }
    }

    IEnumerator ShoesAcquiringSequence()
    {
        musicPlayer.gameObject.SetActive(false);
        acquiringShoes = true;
        shoesSign.gameObject.SetActive(true);
        winSound.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        shoesSign.gameObject.SetActive(false);
        shoesInUI.gameObject.SetActive(true);
        acquiringShoes = false;
        sadFace.gameObject.SetActive(false);
        happyFace.gameObject.SetActive(true);
        StopAllCoroutines();
        gameObject.SetActive(false); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shoesAcquired = true;
        }
    }
}
