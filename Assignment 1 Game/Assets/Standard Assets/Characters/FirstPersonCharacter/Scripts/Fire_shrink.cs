using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_shrink : MonoBehaviour
{
    public float timer;
    public float max_time;
    public float fire_size;
    public float inital_fire_size;
    public GameObject Fire;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        fire_size = inital_fire_size * (timer / max_time);
        if (fire_size >= 0)
        {
            Fire.transform.localScale = new Vector3(fire_size, fire_size, fire_size);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("couldron"))
        {
            timer = max_time;
        }
    }
}
