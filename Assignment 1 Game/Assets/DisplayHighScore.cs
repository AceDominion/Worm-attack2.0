using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Text>().text = DisplayHighScoreList();

    }
	

    private string DisplayHighScoreList()
    {
        string[] scores;
        string display = "";
        if (PlayerPrefs.HasKey("HighScores"))
        {
            Debug.Log("high score string: " + PlayerPrefs.GetString("HighScores"));

            scores = PlayerPrefs.GetString("HighScores").Split(',');
            Array.Sort(scores);
            Array.Reverse(scores);

            foreach (string s in scores)
            {
                display += "\n" + s;
            }

            display = display.Substring(1);

            Debug.Log("high score string format: " + display);
        }
        return display;

    }
}
