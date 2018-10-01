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
    public Vector3 checkpos;
    public GameObject Worm;
    public int attack;
    public float Aspeed;


    List<Checkpoint> Checkpoints;
    public Checkpoint currentCheckpoint;


    // Use this for initialization
    void Start ()
    {
        Checkpoints = new List<Checkpoint>(); // check to see if they all add up
        Checkpoint ck1 = new Checkpoint("ck1",10, 20, 30, 40, 0, 1, 400, 200);
        Checkpoint ck2 = new Checkpoint("ck2",100, 0, 0, 20, 0, 2, 0, 300);
        Checkpoints.Add(ck1);
        Checkpoints.Add(ck2);
        attack = 0;

    }
    public float timeLeft = 10f;

    // Update is called once per frame
    void Update ()
    {
        currX = transform.position.x;
        currZ = transform.position.z;

        if (charge > 10)
        {
            if (direction == -1 )
            {
                if (attack == 0)
                {
                    Worm.transform.position = new Vector3(checkpos.x, checkpos.y + 10, checkpos.z);
                    attack = 1;
                }

                Worm.transform.position = new Vector3(checkpos.x, Worm.transform.position.y - (Time.deltaTime * Aspeed), checkpos.z);

                if (Worm.transform.position.y < (checkpos.y - 20))
                {
                    attack = 0;
                    charge = 0;
                }
                /*
                for (A = 0;  A < 10; A++)
                {
                    Worm.transform.position = new Vector3(checkpos.x, Worm.transform.position.y - Time.deltaTime, checkpos.z);
                }
                */
            }




        }


	}

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (Checkpoint ck in Checkpoints) {
            if (other.name.Contains(ck.name))
            {
                direction = -1;
                currentCheckpoint = ck;
                checkpos = other.transform.position;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        leaveE = other.transform.position.x - exit;
        leaveW = other.transform.position.x + exit;
        leaveN = other.transform.position.z + exit;
        leaveS = other.transform.position.z - exit;

        if (currX > leaveW) //west
        {
            direction = 0;
            distance = leaveW;
        }

        if (currZ > leaveN) //north
        {
            direction = 1;
        }

        if (currX < leaveE) //east
        {
            direction = 2;
        }

        if (currZ < leaveS) //south
        {
            direction = 3;
        }

        distance = currentCheckpoint.B[direction];
    }
}

/// <summary>
///  checkpoints from which to track the player
/// </summary>
class Checkpoint 
{
    public int[] B = { 0, 0, 0, 0 };

    public Checkpoint(string a,int w, int n, int e, int s, int PO, int PT, int PDO, int PDT)
    {
        name = a;
        B[0] = w;
        B[1] = n;
        B[2] = e;
        B[3] = s;
        pathOne = PO;
        pathTwo = PT;
        PDistOne = PDO;
        PDistTwo = PDT;
    }

    public string name;
    public int pathOne;
    public int pathTwo;
    public int PDistOne; // left to right
    public int PDistTwo;
}
