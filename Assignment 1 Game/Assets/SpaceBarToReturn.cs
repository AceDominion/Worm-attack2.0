using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceBarToReturn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("e"))
        {
            Cursor.visible = true;
            Debug.Log("MOUSE VIS");
        }
        if (Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene("Levels");
        }
        if (Input.GetKeyDown("2"))
        {
            SceneManager.LoadScene("map one");
        }
        if (Input.GetKeyDown("3"))
        {
            SceneManager.LoadScene("Mine");
        }
        if (Input.GetKeyDown("space"))
        {
            if (SceneManager.GetSceneByName("title").isLoaded == false)
            {
                SceneManager.LoadScene("Title");
            }
        }
	}

}
