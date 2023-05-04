using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunReload : MonoBehaviour {

    public AudioSource ReloadSound;
    public int ClipCount; //essentially our loaded remaining bullets
    public int ReserveCount; // anything left over from ammo pickups
    public int ReloadAvailable; //empty spots in clip

    private void Update()
    {
        ClipCount = GlobalAmmo.LoadedAmmo; //bullets left in gun
        ReserveCount = GlobalAmmo.CurrentAmmo;

        if (ReserveCount == 0) //if I have no available bullets from ammo packs...
        {
            ReloadAvailable = 0; //no available reload bulllets.
        }
        else
        {
            ReloadAvailable = 10 - ClipCount; //since our gun holds only 10 bullets we can only load a number equal ot the available slots in the clip.
        }
        if(Input.GetButtonDown("Reload"))
        {
            if (ReloadAvailable >= 1)
            {
                if(ReserveCount<= ReloadAvailable)
                {
                    GlobalAmmo.LoadedAmmo += ReserveCount;
                    GlobalAmmo.CurrentAmmo -= ReserveCount;
                    ActionReload();
                }
                else
                {
                    GlobalAmmo.LoadedAmmo += ReloadAvailable;
                    GlobalAmmo.CurrentAmmo -= ReloadAvailable;
                    ActionReload();
                }
            }
            
        }

    }
    void ActionReload()
    {
        ReloadSound.Play();
        GetComponent<Animation>().Play("HandgunReload");
    }
}
