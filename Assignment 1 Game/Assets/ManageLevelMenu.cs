﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageLevelMenu : MonoBehaviour {
    public Button b1;
    public Button b2;
    public Button p;
    string level = "cave";
    public GameObject aztecPic;
    public GameObject cavePic;
    public Text bodyText;
    //Vector3 placement;

    // Use this for initialization
    void Start () {
        //placement = aztecPic.transform.position;
        //Quaternion rotational = aztecPic.transform.rotation;
        Button left = b1.GetComponent<Button>();
        Button right = b2.GetComponent<Button>();
        Button play = p.GetComponent<Button>();

        left.onClick.AddListener(Rotater);
        right.onClick.AddListener(Rotater);
        p.onClick.AddListener(PlaySwitch);
        Rotater();


        for (int i = 1; i < 6; i++)
        {
            GameObject.Find("star" + i).SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		//sets up level select, shows aztec picture
        if(level == "Aztec")
        {

        }
	}

    void Rotater()
    {
        if (level == "aztec")
        {
            level = "cave";
            ClearCreated(false);
            bodyText.text = "The Cave\nHIGHSCORE \nN \nSTUFF";
            Debug.Log("Cave");

            int stars = PlayerPrefs.GetInt("current_collected_number_level_1");
            Debug.Log("level_1 stars: " + stars);
            for(int i = 1; i< stars; i++)
            {
                GameObject.Find("star" + i).SetActive(true);
            }

        }
        else
        {
            level = "aztec";
            ClearCreated(true);
            bodyText.text = "The Aztec Maze\nHIGHSCORE \nN \nSTUFF";
            Debug.Log("Aztec");

            int stars = PlayerPrefs.GetInt("current_collected_number_level_2");
            Debug.Log("level_2 stars: " + stars);

            for (int i = 1; i < stars; i++)
            {
                GameObject.Find("star" + i).SetActive(true);
            }
        }
    }
    void ClearCreated(bool aztec)
    {
        if (aztec)
        {
            aztecPic.SetActive(true);
            cavePic.SetActive(false);
            //aztecPic.transform.Translate(placement);
            //cavePic.transform.Translate(Vector3.forward*5);   
        }
        else
        {
            aztecPic.SetActive(false);
            cavePic.SetActive(true);
            //cavePic.transform.Translate(placement);
            //aztecPic.transform.Translate(Vector3.forward * 5);
        }
    }
    void PlaySwitch()
    {
        if(level == "cave")
        {
            PlayerPrefs.SetInt("Level", 2);
            SceneManager.LoadScene("Mine");
        }
        else
        {
            PlayerPrefs.SetInt("Level", 1);
            SceneManager.LoadScene("Map One");
        }
        
    }
    
}
