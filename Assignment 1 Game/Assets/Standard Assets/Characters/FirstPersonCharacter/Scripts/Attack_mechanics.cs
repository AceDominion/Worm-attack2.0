using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Attack_mechanics : MonoBehaviour {

    public float charge;
    public float buildspeed;
    public float exit = 2;
    public float leaveS;
    public float leaveN;
    public float leaveW;
    public float leaveE;
    public int direction;
    public float currX;
    public float currZ;
    public float distance;

    // Use this for initialization
    void Start ()
    {
        List<Checkpoint> Checkpoints = new List<Checkpoint>(); // check to see if they all add up
        Checkpoint ck1 = new Checkpoint("ck1",100, 200, 300, 400, 0, 1, 400, 200);
        Checkpoint ck2 = new Checkpoint(100, 400, 300, 0, 0, 2, 0, 300);
        Checkpoints.Add(ck1);
        Checkpoints.Add(ck2);
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
            distance = leaveW;
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
    }
}

/// <summary>
///  checkpoints from which to track the player
/// </summary>
class Checkpoint 
{
    public int[] B = { 0, 0, 0, 0 };

    public Checkpoint(int n, int e, int s, int w, int PO, int PT, int PDO, int PDT)
    {
        B[0] = n;
        B[1] = e;
        B[2] = s;
        B[3] = w;
        pathOne = PO;
        pathTwo = PT;
        PDistOne = PDO;
        PDistTwo = PDT;
    }

    public int pathOne;
    public int pathTwo;
    public int PDistOne; // left to right
    public int PDistTwo;
}
