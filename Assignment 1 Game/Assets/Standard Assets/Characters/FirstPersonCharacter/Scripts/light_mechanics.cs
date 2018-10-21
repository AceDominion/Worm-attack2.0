using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_mechanics : MonoBehaviour {


    public float light_level;
    public float timer;
    public float max_time;
    public Light torch;
    public float inital_light_level;

	// Use this for initialization
	void Start ()
    {
        torch.GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        light_level = timer / max_time;
        torch.intensity = light_level * inital_light_level;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("couldron"))
        {
            timer = max_time;
        }

        if (other.name == "couldron")
        {
            timer = max_time;
        }
    }
}
