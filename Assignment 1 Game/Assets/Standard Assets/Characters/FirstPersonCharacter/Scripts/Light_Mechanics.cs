using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Mechanics : MonoBehaviour
{
    public float light_level;
    public float timer;
    public float max_time;
    public float timer2;
    public float max_time2;
    public float light_level2;
    public Light torch;
    public Light torch2;
    public Light torch3;
    public float inital_light_level;
    public float inital_light_level2;

    // Use this for initialization
    void Start()
    {
        torch.GetComponent<Light>();
        torch2.GetComponent<Light>();
        torch3.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        light_level = timer / max_time;
        torch.intensity = light_level * inital_light_level;
        torch2.intensity = light_level * inital_light_level;

        timer2 -= Time.deltaTime;
        light_level2 = timer2 / max_time2;
        torch3.intensity = light_level * inital_light_level2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("couldron"))
        {
            timer = max_time;
            timer2 = max_time2;
        }
    }

    
}
