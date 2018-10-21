using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLight : MonoBehaviour
{

    public GameObject light;
    //public Light lightToDim = null;
    private bool on = false;

    // Use this for initialization
    void OnTriggerStay(Collider plyr)
    {
        if (plyr.tag == "Player" && Input.GetMouseButtonDown(0) && !on)
        {
            light.SetActive(true);
            on = true;

        }
        else if (plyr.tag == "Player" && Input.GetMouseButtonDown(0) && on)
        {
            light.SetActive(false);
            on = false;
        }



    }
}

