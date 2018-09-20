using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Attack_mechanics : MonoBehaviour {

    public float charge;
    public float buildspeed;
    //public GameObject[] checkpoints;
    public float exit = 200;
    public float leaveS;
    public float leaveN;
    public float leaveW;
    public float leaveE;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
  

	}

    private void OnTriggerEnter(Collider other)
    {
        /*int flag;
        for (int i = 0; i<checkpoints.Length; i++) {
            if( other.name.Length > 11)
            {
                flag = int.Parse(other.name.Substring(10, 2));
            }
            else
            {
                flag = int.Parse(other.name.Substring(10, 1));
            }

        }
        if (other.name.Contains("checkpoint")) {

        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        leaveS = other.transform.position.x - exit;
        leaveN = other.transform.position.x + exit;
        leaveW = other.transform.position.z + exit;
        leaveE = other.transform.position.z - exit;
    }
}
