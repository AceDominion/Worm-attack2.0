using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageLevelMenu : MonoBehaviour {
    public Button b1;
    public Button b2;
    string level = "aztec";

	// Use this for initialization
	void Start () {
        Button left = b1.GetComponent<Button>();
        Button right = b2.GetComponent<Button>();

        left.onClick.AddListener(rotater);
        right.onClick.AddListener(rotater);
    }
	
	// Update is called once per frame
	void Update () {
		//sets up level select, shows aztec picture
        if(level == "Aztec")
        {

        }
	}

    void rotater()
    {
        if (level == "aztec")
        {
            level = "cave";
            Debug.Log("Cave");
        }
        else
        {
            level = "aztec";
            Debug.Log("Aztec");
        }
    }
    void clear(bool aztec)
    {
        if (aztec)
        {

        }
        else
        {

        }
    }
    
}
