using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectTotem : MonoBehaviour
{

    public int count;
    public int countSession;
    public int Totem_Number;
    public int HighScore_Display_Number;

    int currLevel;
    string currLevelNumberKey;
    string currLevelHighestNumberKey;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();

        currLevel = PlayerPrefs.GetInt("Level");
        currLevelNumberKey = "current_collected_number_level_" + currLevel;
        currLevelHighestNumberKey = currLevelNumberKey + "_highest";
    }

    private void OnTriggerEnter(Collider other)
    {
        // count the amount of totem, when got the totem
        if (other.tag.Contains("Totem"))
        {
            count++;
            PlayerPrefs.SetInt(currLevelNumberKey, count);
            PlayerPrefs.Save();
            Destroy(other.gameObject);

            Debug.Log("got" + count);
        }

        if (other.name.Contains("door"))
        {
            RecordScore();
            count = 0;
            SceneManager.LoadScene("Victory");
        }

        if (other.transform.name.Contains("worm"))
        {
            RecordScore();
            countSession = 0;
            SceneManager.LoadScene("Death");

        }
    }

    void RecordScore()
    {
        // accumulate the count for current session
        countSession += count;

        // update the highest score for the current level
        if (!PlayerPrefs.HasKey(currLevelHighestNumberKey))
        {
            PlayerPrefs.SetInt(currLevelHighestNumberKey, count);
            PlayerPrefs.Save();

            Debug.Log("【First time to record the high score】for the level" + currLevel + ": " + PlayerPrefs.GetString(currLevelHighestNumberKey));
        }
        else
        {
            if (count > PlayerPrefs.GetInt(currLevelHighestNumberKey))
            {
                PlayerPrefs.SetInt(currLevelHighestNumberKey, count);
                PlayerPrefs.Save();

                Debug.Log("【Update the high score】for the level" + currLevel + ": " + PlayerPrefs.GetString(currLevelHighestNumberKey));
            }
        }

        // add the current score to the score list (all levels together)
        if (!PlayerPrefs.HasKey("HighScores"))
        {
            PlayerPrefs.SetString("HighScores", countSession.ToString());
            PlayerPrefs.Save();

            Debug.Log("First time to add into the list】" + PlayerPrefs.GetString("HighScores"));

        }
        else
        {
            string scores = PlayerPrefs.GetString("HighScores");
            scores = countSession + "," + scores;
            PlayerPrefs.SetString("HighScores", scores);
            PlayerPrefs.Save();

            Debug.Log("【add scores to add into the list】" + PlayerPrefs.GetString("HighScores"));
        }
    }

}


