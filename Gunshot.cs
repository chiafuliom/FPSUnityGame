using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshot : MonoBehaviour
{
    public int DamageAmount = 5; //health to deduct on hit
    public float TargetDistance;
    public float AllowedRange = 35.0f;  //how far away we can be from the target
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalAmmo.LoadedAmmo >= 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("FIRING");
                // flash.SetActive(true);
                //  StartCoroutine(MuzzleOff());
                AudioSource gunsound = GetComponent<AudioSource>();
                gunsound.Play();
                GetComponent<Animation>().Play("KickBack");
                GlobalAmmo.LoadedAmmo -= 1;

                RaycastHit Shot;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))//if anything is in front of my Raycast
                {
                    TargetDistance = Shot.distance; //whatever is hit by the raycast, it's distance gets stored in TargetDistance
                    //Debug.DrawRay(transform.position, transform.forward, Color.green); //print("Hit");
                    if (TargetDistance < AllowedRange) //if the distance between me and the raycast hit is less than the AllowedRange...
                    {
                        Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }
    }
}
