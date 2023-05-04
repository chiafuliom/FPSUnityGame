using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp9mm : MonoBehaviour {

    public float TheDistance;
    public GameObject FakeGun;
    public GameObject RealGun;
    public AudioSource PickUpAudio;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
        if(Input.GetKeyDown(KeyCode.E) && TheDistance <= 10f)
        {
            TakeNineMil();
        }
    }

    void TakeNineMil()
    {
        PickUpAudio.Play();
        FakeGun.SetActive(false);
        RealGun.SetActive(true);
    }
}
