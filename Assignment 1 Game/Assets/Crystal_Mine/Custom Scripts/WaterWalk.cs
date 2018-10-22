using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Characters.FirstPerson;



public class WaterWalk : MonoBehaviour
{
    //public RigidbodyFirstPersonController controller;
    public RigidbodyFirstPersonController.MovementSettings walker;

    void OnTriggerEnter(Collider plyr)
    {
        
        if (plyr.tag == "Player" )
        {
            walker.ForwardSpeed = 1.0f;

        }

    }

    
}
