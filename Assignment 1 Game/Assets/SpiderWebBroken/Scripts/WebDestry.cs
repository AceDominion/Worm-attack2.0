using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebDestry : MonoBehaviour
{

    // Use this for initialization

    public GameObject remains; // this is the prefab, assigned manually in the editor
    //public GameObject theBoy;
    //public GameObject theWeb;

    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerStay(Collider plyr)
    {
        if (plyr.tag == "Player" && Input.GetMouseButtonDown(0))
        {
            Instantiate(remains, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
                Destroy(remains, 2.0f);
            }
        

    }

}