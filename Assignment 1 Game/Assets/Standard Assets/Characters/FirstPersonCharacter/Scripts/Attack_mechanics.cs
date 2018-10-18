using System.Collections;
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
    public int RCD;

    List<Checkpoint> Checkpoints;
    public Checkpoint currentCheckpoint;

    System.Random rnd;


    // Use this for initialization
    void Start ()
    {
        Checkpoints = new List<Checkpoint>(); // dont forget to add f at the end of each number
        Checkpoint ck1 = new Checkpoint("ck1",1.5f, 3.5f, 0, 0, 1.5f, 3.5f, 1.5f, 3.5f);
        Checkpoint ck2 = new Checkpoint("ck2",0, 5f, 1.5f, 0, 1.5f, 5f, 0, 5f);
        Checkpoint ck3 = new Checkpoint("ck3", 0, 0, 9f, 3.5f, 9f, 3.5f, 0, 0);
        Checkpoint ck4 = new Checkpoint("ck4", 9f, 0, 0, 8.5f, 9f, 8.5f, 9f, 0);
        Checkpoint ck5 = new Checkpoint("ck5", 9f, 8.5f, 0, 0, 9f, 8.5f, 9f, 8.5f);
        Checkpoint ck6 = new Checkpoint("ck6", 0, 3f, 9f, 0, 9f, 3f, 0, 3f);
        Checkpoint ck7 = new Checkpoint("ck7", 1.5f, 0, 0, 3f, 1.5f, 3f, 1.5f, 0);
        Checkpoint ck8 = new Checkpoint("ck8", 0, 0, 1.5f, 4.5f, 1.5f, 4.5f, 0, 0);
        Checkpoint ck9 = new Checkpoint("ck9", 0, 4.5f, 6f, 0, 4.5f, 6f, 0, 4.5f);
        Checkpoint ck10 = new Checkpoint("ck10", 6f, 0, 0, 5f, 6f, 5f, 6f, 0);
        Checkpoint ck11 = new Checkpoint("ck11", 2f, 5f, 0, 0, 10f, 5f, 10f, 5f);
        Checkpoint ck12= new Checkpoint("ck12", 8f, 2f, 2f, 0, 10f, 3.5f, 8f, 3.5f);
        Checkpoint ck13 = new Checkpoint("ck13", 0, 9.5f, 8f, 0, 10f, 9.5f, 0, 9.5f);
        Checkpoint ck14 = new Checkpoint("ck14", 1.5f, 0, 0, 9.5f, 1.5f, 9.5f, 1.5f, 0);
        Checkpoint ck15 = new Checkpoint("ck15", 0, 0, 1.5f, 11.5f, 1.5f, 11.5f, 0, 0);
        Checkpoint ck16 = new Checkpoint("ck16", 0, 11.5f, 6.5f, 0, 6.5f, 11.5f, 0, 11.5f);
        Checkpoint ck17 = new Checkpoint("ck17", 6.5f, 1.5f, 0, 2f, 6.5f, 3.5f, 6.5f, 1.5f);
        Checkpoint ck18 = new Checkpoint("ck18", 5f, 0, 0, 1.5f, 5f, 3.5f, 5f, 0);
        Checkpoint ck19 = new Checkpoint("ck19", 0, 8.5f, 5f, 0, 5f, 15.5f, 0, 15.5f);
        Checkpoint ck20 = new Checkpoint("ck20", 1.5f, 7f, 0, 8.5f, 4.5f, 15.5f, 4.5f, 7f);
        Checkpoint ck21 = new Checkpoint("ck21", 1.5f, 8.5f, 1.5f, 10f, 4.5f, 18.5f, 3f, 8.5f);
        Checkpoint ck22 = new Checkpoint("ck22", 1.5f, 10f, 1.5f, 0, 4.5f, 10f, 1.5f, 10f);
        Checkpoint ck23 = new Checkpoint("ck23", 0, 12f, 1.5f, 0, 4.5f, 12f, 0, 12f);
        Checkpoint ck24 = new Checkpoint("ck24", 0, 0, 7f, 12f, 7f, 12f, 0, 0);
        Checkpoint ck25 = new Checkpoint("ck25", 7f, 1.5f, 0, 0, 7f, 3.5f, 7f, 1.5f);
        Checkpoint ck26 = new Checkpoint("ck26", 7f, 2f, 0, 1.5f, 7f, 3.5f, 7f, 2f);
        Checkpoint ck27 = new Checkpoint("ck27", 7f, 0, 2f, 2f, 9f, 3.5f, 7f, 0);
        Checkpoint ck28 = new Checkpoint("ck28", 2f, 0, 0, 5.5f, 2f, 7f, 2f, 0);
        Checkpoint ck29 = new Checkpoint("ck29", 7.5f, 5.5f, 0, 1.5f, 7.5f, 7f, 7.5f, 5.5f);
        Checkpoint ck30 = new Checkpoint("ck30", 0, 0, 7.5f, 10f, 7.5f, 10f, 0, 0);
        Checkpoint ck31 = new Checkpoint("ck31", 6f, 1.5f, 2f, 0, 8f, 7f, 6f, 7f);
        Checkpoint ck32 = new Checkpoint("ck32", 2f, 0, 0, 1.5f, 2f, -1, 2f, -1);// NULL here = -1
        Checkpoint ck33 = new Checkpoint("ck33", 6.5f, 1.5f, 9.5f, 0, 16f, 1.5f, 6.5f, 1.5f);
        Checkpoint ck34 = new Checkpoint("ck34", 0, 0, 6.5f, 7f, 16f, 15.5f, 0, 0);
        Checkpoint ck35 = new Checkpoint("ck35", 9.5f, 0, 0, 15.5f, 16f, 15.5f, 16f, 0);
        Checkpoint ck36 = new Checkpoint("ck36", 0, 10f, 6.5f, 0, 6.5f, 18.5f, 0, 18.5f);
        Checkpoint ck37 = new Checkpoint("ck37", 5.5f, 15.5f, 0, 0, 5.5f, 15.5f, 5.5f, 15.5f);
        Checkpoint ck38 = new Checkpoint("ck38", 0, 0, 5.5f, 1.5f, 5.5f, 3f, 0, 0);
        Checkpoint ck39 = new Checkpoint("ck39", 0, 1.5f, 7f, 1.5f, 7f, 3f, 0, 1.5f);
        Checkpoint ck40 = new Checkpoint("ck40", 2f, 1.5f, 1.5f, 0, 11f, 3f, 2f, 3f);
        Checkpoint ck41 = new Checkpoint("ck41", 0, 3f, 2f, 0, 11f, 3f, 0, 3f);
        Checkpoint ck42 = new Checkpoint("ck42", 0, 0, 5.5f, 3f, 5.5f, 3f, 0, 0);
        Checkpoint ck43 = new Checkpoint("ck43", 5.5f, 11.5f, 0, 0, 5.5f, 11.5f, 5.5f, 11.5f);
        Checkpoint ck44 = new Checkpoint("ck44", 12f, 0, 0, 11.5f, 12f, 11.5f, 12f, 0);
        Checkpoint ck45 = new Checkpoint("ck45", 0, 0, 12f, 5f, 12f, 5f, 0, 0);
        Checkpoint ck46 = new Checkpoint("ck46", 7f, 8f, 0, 0, 7f, 8f, 7f, 8f);
        Checkpoint ck47 = new Checkpoint("ck47", 0, 0, 8f, 8f, 8f, 8f, 0, 0);
        Checkpoint ck48 = new Checkpoint("ck48", 1.5f, 0, 7.5f, 2f, 11f, 2f, 3.5f, 0);
        Checkpoint ck49 = new Checkpoint("ck49", 7.5f, 6.5f, 0, 0, 11f, 6.5f, 11f, 6.5f);
        Checkpoint ck50 = new Checkpoint("ck50", 0, 0, 5f, 6.5f, 5f, 6.5f, 0, 0);
        Checkpoint ck51 = new Checkpoint("ck51", 5f, 0, 0, 6.5f, 5f, 6.5f, 5f, 0);
        Checkpoint ck52 = new Checkpoint("ck52", 0, 6.5f, 2f, 0, 2f, 6.5f, 0, 6.5f);
        Checkpoint ck53 = new Checkpoint("ck53", 8.5f, 2f, 12.5f, 0, 27f, 2f, 8.5f, 2f);
        Checkpoint ck54 = new Checkpoint("ck54", 12.5f, 4f, 2f, 0, 27f, -1, 21f, -1); // NULL here = -1
        Checkpoint ck55 = new Checkpoint("ck55", 2f, 4f, 4f, 0, 27f, -1, 23f, -1); // NULL here = -1
        Checkpoint ck56 = new Checkpoint("ck56", 0, 1f, 7f, 0, 7f, 1f, 0, 1f);
        Checkpoint ck57 = new Checkpoint("ck57", 0, 0, 6f, 8.5f, 8f, 18.5f, 6f, 0);

        Checkpoints.Add(ck1);
        Checkpoints.Add(ck2);
        Checkpoints.Add(ck3);
        Checkpoints.Add(ck4);
        Checkpoints.Add(ck5);
        Checkpoints.Add(ck6);
        Checkpoints.Add(ck7);
        Checkpoints.Add(ck8);
        Checkpoints.Add(ck9);
        Checkpoints.Add(ck11);
        Checkpoints.Add(ck12);
        Checkpoints.Add(ck13);
        Checkpoints.Add(ck14);
        Checkpoints.Add(ck15);
        Checkpoints.Add(ck16);
        Checkpoints.Add(ck17);
        Checkpoints.Add(ck18);
        Checkpoints.Add(ck19);
        Checkpoints.Add(ck20);
        Checkpoints.Add(ck21);
        Checkpoints.Add(ck22);
        Checkpoints.Add(ck23);
        Checkpoints.Add(ck24);
        Checkpoints.Add(ck25);
        Checkpoints.Add(ck26);
        Checkpoints.Add(ck27);
        Checkpoints.Add(ck28);
        Checkpoints.Add(ck29);
        Checkpoints.Add(ck30);
        Checkpoints.Add(ck31);
        Checkpoints.Add(ck32);
        Checkpoints.Add(ck33);
        Checkpoints.Add(ck34);
        Checkpoints.Add(ck35);
        Checkpoints.Add(ck36);
        Checkpoints.Add(ck37);
        Checkpoints.Add(ck38);
        Checkpoints.Add(ck39);
        Checkpoints.Add(ck40);
        Checkpoints.Add(ck41);
        Checkpoints.Add(ck42);
        Checkpoints.Add(ck43);
        Checkpoints.Add(ck44);
        Checkpoints.Add(ck45);
        Checkpoints.Add(ck46);
        Checkpoints.Add(ck47);
        Checkpoints.Add(ck48);
        Checkpoints.Add(ck49);
        Checkpoints.Add(ck50);
        Checkpoints.Add(ck51);
        Checkpoints.Add(ck52);
        Checkpoints.Add(ck53);
        Checkpoints.Add(ck54);
        Checkpoints.Add(ck55);
        Checkpoints.Add(ck56);
        Checkpoints.Add(ck57);


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
        int RCDattack = rnd.Next(1, 3);

        //_____________________________________________________________________________________________________________________________________________________________________________________________________

        if (charge >= 100 || attack == 1)
        {
            if ((direction == -1 && SWattack == 0 && CDattack == 0) || CPattack == 1) //checkpoint attack - done I think
            {
                CPattack = 1;
                if (attack == 0)
                {
                    if (RCattack == 1)
                    {
                        Worm.transform.position = new Vector3(checkpos.x, checkpos.y + Afrom, checkpos.z);
                        Worm.transform.rotation = new Quaternion(0, 0, 0, 0);
                        Adirection = 1;
                    }
                    else if ( RCattack == 2)
                    {
                        Worm.transform.position = new Vector3(checkpos.x, checkpos.y - Afrom, checkpos.z);
                        Worm.transform.rotation = new Quaternion(0, 180, 0, 0);
                        Adirection = 2;
                    }
                    attack = 1;
                }

                if (Adirection == 1)
                {
                    Worm.transform.position = new Vector3(checkpos.x, Worm.transform.position.y - (Time.deltaTime * Aspeed), checkpos.z);
                }
                if (Adirection == 2)
                {
                    Worm.transform.position = new Vector3(checkpos.x, Worm.transform.position.y + (Time.deltaTime * Aspeed), checkpos.z);
                }

                if (((Worm.transform.position.y < (checkpos.y - Adistance) && Adirection == 1) || ((Worm.transform.position.y > (checkpos.y + Adistance)) && Adirection == 2)) || timer <= 0)
                {
                    //make worm disappear
                    attack = 0;
                    CPattack = 0;
                    SWattack = 0;
                    CDattack = 0;
                    cooldown = 1; // cooldown only stops attacks when the attack finishes not while the attack is happening
                    timer = reset;
                }
            }

            //_____________________________________________________________________________________________________________________________________________________________________________________________________

            if ((attacktype < 20 || SWattack == 1) && cooldown == 0) //corridor wall to wall attack
            {
                RCD = 1;
                SWattack = 1;
                if (attack == 0)
                {
                    RCD = 2;
                    if (direction == 0 || direction == 2)
                    {
                        RCD = 3;
                        if (RWattack == 1)
                        {
                            Worm.transform.position = new Vector3(transform.position.x, transform.position.y - Afrom, transform.position.z);// up
                            Worm.transform.rotation = new Quaternion(0, 90, 0, 90);
                            Adirection = 0;
                        }
                        else if (RWattack == 2)
                        {
                            Worm.transform.position = new Vector3(transform.position.x, transform.position.y + Afrom, transform.position.z);// down
                            Worm.transform.rotation = new Quaternion(0, -90, 0, 90);
                            Adirection = 1;
                        }
                        else if (RWattack == 3)
                        {
                            Worm.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Afrom);// left
                            Worm.transform.rotation = new Quaternion(90, 0, 0, 90);
                            Adirection = 2;
                        }
                        else if (RWattack == 4)
                        {
                            Worm.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Afrom);// right
                            Worm.transform.rotation = new Quaternion(-90, 0, 0, 90);
                            Adirection = 3;
                        }
                        attack = 1;
                    }

                }
            
            


                if (Adirection == 0)// up
                {
                    Worm.transform.position = new Vector3(Worm.transform.position.x, Worm.transform.position.y + (Time.deltaTime * Aspeed), Worm.transform.position.z);
                }
                if (Adirection == 1)// down
                {
                    Worm.transform.position = new Vector3(Worm.transform.position.x, Worm.transform.position.y - (Time.deltaTime * Aspeed), Worm.transform.position.z);
                }
                if (Adirection == 2)
                {
                    Worm.transform.position = new Vector3(Worm.transform.position.x, Worm.transform.position.y, Worm.transform.position.z + (Time.deltaTime * Aspeed));
                }
                if (Adirection == 3)
                {
                    Worm.transform.position = new Vector3(Worm.transform.position.x, Worm.transform.position.y, Worm.transform.position.z - (Time.deltaTime * Aspeed));
                }

                if (((Worm.transform.position.y > (transform.position.y + Adistance) && Adirection == 0) || (Worm.transform.position.y > (transform.position.y - Adistance) && Adirection == 1) || (Worm.transform.position.z < (transform.position.z + Adistance) && Adirection == 2) || (Worm.transform.position.z < (transform.position.z - Adistance) && Adirection == 3)) || timer <= 0)
                {
                    attack = 0;
                    CPattack = 0;
                    SWattack = 0;
                    CDattack = 0;
                    cooldown = 1;
                    timer = reset;
                    Adirection = -2;
                    RCD = 0;
                }
            }


            //__________________________________________________________________________________________________________________________________________________________________________________________________________________

            if ((attacktype == 22 || CDattack == 1) && cooldown == 0) // corridor attack - done I think
            {
                CDattack = 1;
                if (attack == 0)
                {
                    if (direction == 0 || direction == 2)
                    {
                        float Dpath = currentCheckpoint.DistanceOnPathOne; //west to east
                        float pathD = currentCheckpoint.PathOneDistance; //west to east
                        float correction = 0;

                        if (Dpath == 0 && RCDattack == 2) // 2 = + and 1 = -
                        {
                            correction = 0;
                        }
                        else if (Dpath == 0 && RCDattack == 1)
                        {
                            correction = pathD;
                        }
                        else if (Dpath > 0 && RCDattack == 2)
                        {
                            correction = Dpath;
                        }
                        else if (Dpath > 0 && RCDattack == 1)
                        {
                            correction = pathD - Dpath;
                        }

                        if (direction == 0 || direction == 2)
                        {
                            if (RCDattack == 2) //-X
                            {
                                Worm.transform.position = new Vector3(checkpos.x - correction - Afrom, checkpos.y, checkpos.z);
                                Worm.transform.rotation = new Quaternion(0, 0, -90, 90);
                                Adirection = 0;
                            }
                            else if (RCDattack == 1) //+X
                            {
                                Worm.transform.position = new Vector3(checkpos.x + correction + Afrom, checkpos.y, checkpos.z);
                                Worm.transform.rotation = new Quaternion(0, 0, 90, 90);
                                Adirection = 2;
                            }
                        }
                    }
                    else if (direction == 1 || direction == 3)
                    {
                        float Dpath = currentCheckpoint.DistanceOnPathTwo; //north to south
                        float pathD = currentCheckpoint.PathTwoDistance; //north to south
                        float correction = 0;

                        if (Dpath == 0 && RCDattack == 2) // 2 = + and 1 = -
                        {
                            correction = 0;
                        }
                        else if (Dpath == 0 && RCDattack == 1)
                        {
                            correction = pathD;
                        }
                        else if (Dpath > 0 && RCDattack == 2)
                        {
                            correction = Dpath;
                        }
                        else if (Dpath > 0 && RCDattack == 1)
                        {
                            correction = pathD - Dpath;
                        }

                        if (RCDattack == 2) //-X
                        {
                            Worm.transform.position = new Vector3(checkpos.x, checkpos.y, checkpos.z - correction - Afrom);
                            Worm.transform.rotation = new Quaternion(-90, 0, 0, 90);
                            Adirection = 1;
                        }
                        else if (RCDattack == 1) //+X
                        {
                            Worm.transform.position = new Vector3(checkpos.x, checkpos.y, checkpos.z + correction + Afrom);
                            Worm.transform.rotation = new Quaternion(90, 0, 0, 90);
                            Adirection = 3;
                        }
                    }
                    attack = 1;
                }

                if (Adirection == 0)
                {
                    Worm.transform.position = new Vector3(Worm.transform.position.x + (Time.deltaTime * Aspeed), Worm.transform.position.y, Worm.transform.position.z);
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
                    Worm.transform.position = new Vector3(Worm.transform.position.x, Worm.transform.position.y, Worm.transform.position.z - (Time.deltaTime * Aspeed));
                }

                if (((Worm.transform.position.x > (transform.position.x + Adistance) && Adirection == 0) || (Worm.transform.position.z > (transform.position.z + Adistance) && Adirection == 1) || (Worm.transform.position.x < (transform.position.x - Adistance) && Adirection == 2) || (Worm.transform.position.z < (transform.position.z - Adistance) && Adirection == 3)) || timer <= 0)
                {
                    attack = 0;
                    CPattack = 0;
                    SWattack = 0;
                    CDattack = 0;
                    cooldown = 1;
                    timer = reset;
                    Adirection = -2;
                }
            }


            cooldown = 0;
            timer -= Time.deltaTime;
            charge = 0;

        }

    }

    //_____________________________________________________________________________________________________________________________________________________________________________________________________

    private void OnTriggerEnter(Collider other)
    {
        foreach (Checkpoint ck in Checkpoints) {
            if (other.name.Contains(ck.name))
            {
                direction = -1;
                distance = 0;
                currentCheckpoint = ck;
                checkpos = other.transform.position;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        leaveW = other.transform.position.x - exit;
        leaveE = other.transform.position.x + exit;
        leaveN = other.transform.position.z + exit;
        leaveS = other.transform.position.z - exit;

        if (currX > leaveE) //west
        {
            direction = 0;
        }

        if (currZ > leaveN) //north
        {
            direction = 1;
        }

        if (currX < leaveW) //east
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
    public float[] B = { 0, 0, 0, 0 };

    public Checkpoint(string Name,float west, float north, float east, float south, float POD, float PTD, float DPO, float DPT)
    {
        name = Name;
        B[0] = east;
        B[1] = north;
        B[2] = west;
        B[3] = south;
        PathOneDistance = POD;
        PathTwoDistance = PTD;
        DistanceOnPathOne = DPO;
        DistanceOnPathTwo = DPT;
    }

    public string name;
    public float PathOneDistance;
    public float PathTwoDistance;
    public float DistanceOnPathOne; // left to right
    public float DistanceOnPathTwo; // up to down
}
