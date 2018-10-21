using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageLevelMenu : MonoBehaviour {
    public Button b1;
    public Button b2;
    string level = "aztec";
    public GameObject aztecPic;
    public GameObject cavePic;
    Vector3 placement

    // Use this for initialization
    void Start () {
        placement = aztecPic.transform.position;
        Quaternion rotational = aztecPic.transform.rotation;
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
            ClearCreated(false);
            Debug.Log("Cave");
        }
        else
        {
            level = "aztec";
            ClearCreated(true);
            Debug.Log("Aztec");
        }
    }
    void ClearCreated(bool aztec)
    {
        if (aztec)
        {
            aztecPic.transform.Translate(placement);
            cavePic.transform.Translate(Vector3.forward*5);
        }
        else
        {
            cavePic.transform.Translate(placement);
            aztecPic.transform.Translate(Vector3.forward * 5);
        }
    }
    
}
