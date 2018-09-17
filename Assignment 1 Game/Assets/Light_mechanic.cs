using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_mechanic : MonoBehaviour {

    public Light lt;
    public int intensity = 0;
    void Start()
    {
        lt = GetComponent<Light>();
        lt.intensity = intensity;
    }

    // Update is called once per frame
    void Update () {
		
	}

  
}
