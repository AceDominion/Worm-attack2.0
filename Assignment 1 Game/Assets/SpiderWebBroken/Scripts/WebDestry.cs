using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebDestry : MonoBehaviour
{

    // Use this for initialization

    public GameObject remains; // this is the prefab, assigned manually in the editor
    public GameObject theBoy;
    public GameObject theWeb;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(0) & theBoy.transform.position.x < theWeb.transform.position.x + 2f)
            {
                Instantiate(remains, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
                Destroy(remains, 2.0f);
            }
        

    }

}