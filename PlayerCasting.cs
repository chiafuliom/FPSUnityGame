using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{

    public static float DistanceFromTarget;
    public float ToTarget;
   
  
   
    void Start()
    {
       
    }
   
void Update()
    {

        
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            ToTarget = hit.distance;
            DistanceFromTarget = ToTarget;

           
        }
       


    }

}



