using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public static int bulletsInScene;
    public Text displayBullets;

    private void Awake()
    {
        bulletsInScene = 0;
    }

    void Update()
    {
        displayBullets.text = "Bullets left: " + (30 - bulletsInScene) + " / 30";
    }
}
