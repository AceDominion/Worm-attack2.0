using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour {

    public Transform target;
    public Camera cam;
    public GameObject map;
    public bool FollowByTorch;

    bool flagMaxMap = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!flagMaxMap && Input.GetKeyDown(KeyCode.M))
        {
            var mapTransform = map.transform as RectTransform;
            mapTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
            flagMaxMap = true;
        }
        else if (flagMaxMap && Input.GetKeyDown(KeyCode.M))
        {
            var mapTransform = map.transform as RectTransform;
            mapTransform.sizeDelta = new Vector2(180, 180);
            flagMaxMap = false;
        }

        
	}

    private void OnGUI()
    {
        if (FollowByTorch)
            transform.position = cam.WorldToScreenPoint(new Vector3(target.position.x + 1, target.position.y - 1)); //also need to reset the anchor 

        // transform.position = new Vector3(cam.WorldToScreenPoint(target.transform.position).x + 300, cam.WorldToScreenPoint(target.transform.position).y+300) ;

    }
}
