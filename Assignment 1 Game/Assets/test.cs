using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public Light[] lt;
    public float[] intensity;
    public float timeLeft;
    public float charge;

	// Use this for initialization
	void Start () {
        lt[0].intensity = intensity[0];
        lt[1].intensity = intensity[1];

    }

    // Update is called once per frame
    void Update () {
        timeLeft -= Time.deltaTime;
        lt[0].intensity = timeLeft / 60;
        lt[1].intensity = timeLeft / 60;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("WoodenBeams (2)  test pot"))
        {
            timeLeft = 60;
        }

        if (other.gameObject.name == "Web")
        {
            Destroy(other.gameObject);
        }
    }
}
