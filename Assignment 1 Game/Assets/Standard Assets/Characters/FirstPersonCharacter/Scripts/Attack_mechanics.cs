using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Attack_mechanics : MonoBehaviour {

    public float charge;
    public float buildspeed;
    //public GameObject[] checkpoints;
    public float exit = 2;
    public float leaveS;
    public float leaveN;
    public float leaveW;
    public float leaveE;
    public int direction;
    public float currX;
    public float currZ;

    // Use this for initialization
    void Start ()
    {
        int[][] distance = { 100, 200, 300, 200 }, { 1,2 };
        Dictionary<int, int> d1 = new Dictionary<int, int>();
        d.Add(1, 100);

        d.Add(2, 200);

        int b = d[1];

        Dictionary<int, int> d2 = new Dictionary<int, int>();

        Dictionary<int, int>[] ds = { , d2 };


        List<int[]> ck = new List<int[]>(); // path list
        ck.
	}


	// Update is called once per frame
	void Update ()
    {
        currX = transform.position.x;
        currZ = transform.position.z;


	}

    private void FixedUpdate()
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
        leaveE = other.transform.position.x - exit;
        leaveW = other.transform.position.x + exit;
        leaveN = other.transform.position.z + exit;
        leaveS = other.transform.position.z - exit;

        if (currX > leaveW) //west
        {
            direction = 1;
        }

        if (currZ > leaveN) //north
        {
            direction = 2;
        }

        if (currX < leaveE) //east
        {
            direction = 3;
        }

        if (currZ < leaveS) //south
        {
            direction = 4;
        }

        Dictionary<int, List<int>> ck = new Dictionary<int, List<int>>();
        int[] corrdW = [1, 100];
        int[] corrdE = [3, 100];


        ck.Add(1, new List<int[]> { new int[]{ 1, 200 }, new int[] { 2, 200 });
    }
}
