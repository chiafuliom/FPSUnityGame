using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class GlobalAmmo : MonoBehaviour
{
    public static int CurrentAmmo;
    public int ReserveAmmo;
    public GameObject AmmoDisplay;

    public static int LoadedAmmo;
    public int ReserveLoaded;
    public GameObject LoadedDisplay;

    private void Start()
    {
        ReserveAmmo = 0;
        LoadedAmmo = 6;
    }
    void Update()
    {
        ReserveAmmo = CurrentAmmo;

        ReserveLoaded = LoadedAmmo;
        AmmoDisplay.GetComponent<Text>().text = "Reserve Ammo: " + ReserveAmmo;
        LoadedDisplay.GetComponent<Text>().text = "Loaded Ammo: " + LoadedAmmo;
    }
}
