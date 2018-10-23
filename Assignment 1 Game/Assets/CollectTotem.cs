using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectTotem : MonoBehaviour {

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

        #region delete
        /*
        // record the total credit, when pass the door or caught by the worm
        if (other.name.Contains("door_test") || other.name.Contains("worm")) 
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

            // reset the count, and pop up the result
            count = 0;
            if (other.name.Contains("worm")) //reset the session's count only if it is caught by the worm
            {
                countSession = 0;    
                // pop up "You Died" //待更新
            }            

            // Go to Died or Win
            if (other.name.Contains("door_test"))
            {
                // pop up "Win" //待更新
            }
        }
        */
        #endregion
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.Contains("worm"))
        {
            Debug.Log("hi caught you");
            RecordScore();
            countSession = 0;
            SceneManager.LoadScene("Death", LoadSceneMode.Additive);

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



