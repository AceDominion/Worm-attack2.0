﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    public int CPattack;
    public int SWattack;
    public int CDattack;
    public int Adistance;
    public int Adirection;
    public int Afrom;
    public int cooldown;
    public float timer;
    public float reset;

    List<Checkpoint> Checkpoints;
    public Checkpoint currentCheckpoint;

    System.Random rnd;


    // Use this for initialization
    void Start ()
    {
        Checkpoints = new List<Checkpoint>(); // check to see if they all add up
        Checkpoint ck1 = new Checkpoint("ck1",20, 0, 0, 20, 20, 0, 0, 0);
        Checkpoint ck2 = new Checkpoint("ck2",0, 20, 20, 0, 20, 20, 20, 20);
        Checkpoints.Add(ck1);
        Checkpoints.Add(ck2);
        attack = 0;
        direction = -2;
        rnd = new System.Random();

    }

    // Update is called once per frame
    void Update ()
    {
        currZ = transform.position.z;
        currX = transform.position.x;


        int attacktype = rnd.Next(1,21);
        int RWattack = rnd.Next(1, 5);
        int RCattack = rnd.Next(1, 3);

        if ((charge > 100 || attack == 1) && cooldown == 0)
        {
            if (((direction == -1 && SWattack == 0 && CDattack == 0) || CPattack == 1) && cooldown == 0) //checkpoint attack
            {
                CPattack = 1;
                if (attack == 0)
                {
                    if (RCattack == 1)
                    {
                        Worm.transform.position = new Vector3(checkpos.x, checkpos.y + Afrom, checkpos.z);
                        Worm.transform.rotation = new Quaternion(0, 0, 0, 0);
                        attack = 1;
                        Adirection = 1;
                    }
                    else if ( RCattack == 2)
                    {
                        Worm.transform.position = new Vector3(checkpos.x, checkpos.y - Afrom, checkpos.z);
                        Worm.transform.rotation = new Quaternion(0, 0, 0, 0);
                        attack = 1;
                        Adirection = 2;
                    }
                }

                if (Adirection == 1)
                {
                    Worm.transform.position = new Vector3(checkpos.x, Worm.transform.position.y - (Time.deltaTime * Aspeed), checkpos.z);
                }
                if (Adirection == 2)
                {
                    Worm.transform.position = new Vector3(checkpos.x, Worm.transform.position.y + (Time.deltaTime * Aspeed), checkpos.z);
                }
                charge = 0;
                timer -= Time.deltaTime;

                if (((Worm.transform.position.y < (checkpos.y - Adistance) && Adirection == 1) || ((Worm.transform.position.y > (checkpos.y + Adistance)) && Adirection == 2) || timer <= 0))
                {
                    //make worm disappear
                    attack = 0;
                    CPattack = 0;
                    cooldown = 1; // cooldown only stops attacks when the attack finishes not while the attack is happening
                    timer = reset;
                }
            }

            if ((attacktype < 1 || SWattack == 1) && cooldown == 0) //corridor wall to wall attack
            {
                SWattack = 1;
                if (attack == 0)
                {
                    if (direction == 0 || direction == 2)
                    {
                        if (RWattack == 1)
                        {
                            Worm.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Afrom);// change to correct position
                            Worm.transform.rotation = new Quaternion(90, 0, 0, 90);
                            attack = 1;
                            Adirection = 0;
                        }
                        else if (RWattack == 2)
                        {
                            Worm.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Afrom);// change to correct position
                            Worm.transform.rotation = new Quaternion(90, 0, 0, 90);
                            attack = 1;
                            Adirection = 1;
                        }
                        else if (RWattack == 3)
                        {
                            Worm.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Afrom);// change to correct position
                            Worm.transform.rotation = new Quaternion(90, 0, 0, 90);
                            attack = 1;
                            Adirection = 2;
                        }
                        else if (RWattack == 4)
                        {
                            Worm.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Afrom);// change to correct position
                            Worm.transform.rotation = new Quaternion(90, 0, 0, 90);
                            attack = 1;
                            Adirection = 3;
                        }
                    }

                    if (direction == 1 || direction == 3) // two of the directions are wrong
                    {
                        if (RWattack == 1)
                        {
                            Worm.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Afrom);// change to correct position
                            Worm.transform.rotation = new Quaternion(90, 0, 0, 90);
                            attack = 1;
                            Adirection = 0;
                        }
                        else if (RWattack == 2)
                        {
                            Worm.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Afrom);// change to correct position
                            Worm.transform.rotation = new Quaternion(90, 0, 0, 90);
                            attack = 1;
                            Adirection = 1;
                        }
                        else if (RWattack == 3)
                        {
                            Worm.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Afrom);// change to correct position
                            Worm.transform.rotation = new Quaternion(90, 0, 0, 90);
                            attack = 1;
                            Adirection = 2;
                        }
                        else if (RWattack == 4)
                        {
                            Worm.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Afrom);// change to correct position
                            Worm.transform.rotation = new Quaternion(90, 0, 0, 90);
                            attack = 1;
                            Adirection = 3;
                        }
                    }
                }
            
            


                if (Adirection == 0)
                {
                    Worm.transform.position = new Vector3(Worm.transform.position.x, Worm.transform.position.y, Worm.transform.position.z - (Time.deltaTime * Aspeed));
                }
                if (Adirection == 1)
                {
                    Worm.transform.position = new Vector3(Worm.transform.position.x, Worm.transform.position.y, Worm.transform.position.z + (Time.deltaTime * Aspeed));
                }
                if (Adirection == 2)
                {
                    Worm.transform.position = new Vector3(Worm.transform.position.x - (Time.deltaTime * Aspeed), Worm.transform.position.y, Worm.transform.position.z);
                }
                if (Adirection == 3)
                {
                    Worm.transform.position = new Vector3(Worm.transform.position.x + (Time.deltaTime * Aspeed), Worm.transform.position.y, Worm.transform.position.z);
                }
                charge = 0;
                timer -= Time.deltaTime;

                if (((Worm.transform.position.x > (transform.position.x + Adistance) && Adirection == 0) || (Worm.transform.position.z > (transform.position.z + Adistance) && Adirection == 1) || (Worm.transform.position.x < (transform.position.x - Adistance) && Adirection == 2) || (Worm.transform.position.z < (transform.position.z - Adistance) && Adirection == 3)) || timer <= 0)
                {
                    attack = 0;
                    SWattack = 0;
                    cooldown = 1;
                    timer = reset;
                }

            }

            if ((attacktype >= 2 || CDattack == 1) && cooldown == 0)
            {
                CDattack = 1;
                if (attack == 0)
                {
                    if (direction == 0 || direction == 2)
                    {
                        int Dpath = currentCheckpoint.PDistOne;
                        int pathD = Dpath - currentCheckpoint.pathOne; //left to right
                        Worm.transform.position = new Vector3(checkpos.x + Dpath +  Afrom, checkpos.y, checkpos.z); //work position out
                        Worm.transform.rotation = new Quaternion(0, 0, 90, 90);
                        Adirection = 2;
                    }
                    else if (direction == 1 || direction == 3)
                    {
                        int Dpath = currentCheckpoint.PDistTwo;
                        int pathD = Dpath - currentCheckpoint.pathTwo; //up to down
                        Worm.transform.position = new Vector3(checkpos.x, checkpos.y, checkpos.z + Dpath + Afrom); //work position out
                        Worm.transform.rotation = new Quaternion(90, 0, 0, 90);
                        Adirection = 1;
                    }
                    attack = 1;
                }

                if (Adirection == 0)
                {
                    Worm.transform.position = new Vector3(Worm.transform.position.x, Worm.transform.position.y, Worm.transform.position.z - (Time.deltaTime * Aspeed));
                }
                if (Adirection == 1)
                {
                    Worm.transform.position = new Vector3(Worm.transform.position.x, Worm.transform.position.y, Worm.transform.position.z + (Time.deltaTime * Aspeed));
                }
                if (Adirection == 2)
                {
                    Worm.transform.position = new Vector3(Worm.transform.position.x - (Time.deltaTime * Aspeed), Worm.transform.position.y, Worm.transform.position.z);
                }
                if (Adirection == 3)
                {
                    Worm.transform.position = new Vector3(Worm.transform.position.x + (Time.deltaTime * Aspeed), Worm.transform.position.y, Worm.transform.position.z);
                }
                charge = 0;
                timer -= Time.deltaTime;

                if (((Worm.transform.position.x > (transform.position.x + Adistance) && Adirection == 0) || (Worm.transform.position.z > (transform.position.z + Adistance) && Adirection == 1) || (Worm.transform.position.x < (transform.position.x - Adistance) && Adirection == 2) || (Worm.transform.position.z < (transform.position.z - Adistance) && Adirection == 3)) || timer <= 0)
                {
                    attack = 0;
                    CDattack = 0;
                    cooldown = 1;
                    timer = reset;
                    Adirection = -2;
                }
            }




        }

        cooldown = 0;

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

    public Checkpoint(string a,int w, int n, int e, int s, int PDO, int PDT, int DPO, int DPT)
    {
        name = a;
        B[0] = w;
        B[1] = n;
        B[2] = e;
        B[3] = s;
        pathOne = PDO;
        pathTwo = PDT;
        PDistOne = DPO;
        PDistTwo = DPT;
    }

    public string name;
    public int pathOne;
    public int pathTwo;
    public int PDistOne; // left to right
    public int PDistTwo;
}
