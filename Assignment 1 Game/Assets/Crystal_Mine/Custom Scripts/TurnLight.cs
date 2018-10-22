using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TurnLight : MonoBehaviour
{

    public GameObject TheLight;
    
    private bool on = false;

    // Use this for initialization
    void OnTriggerStay(Collider plyr)
    {
        if (plyr.tag == "Player" && Input.GetMouseButtonDown(0) && !on)
        {
            TheLight.SetActive(true);
            on = true;

        }
        else if (plyr.tag == "Player" && Input.GetMouseButtonDown(0) && on)
        {
            TheLight.SetActive(false);
            on = false;
        }



    }
}

