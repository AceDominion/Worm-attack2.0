using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemRotate : MonoBehaviour {
    int height = 0; //range from minus to positive, controls "bobbing"
    bool up; //true = going up, false = down.
    public int speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * (Time.deltaTime* speed));

        if (up) //neg
        {
            transform.Translate(Vector3.up / 400);
            //transform.position = Vector3.up * Time.deltaTime;
            //transform.position = new Vector3(0.0f, 2f);
            height++;
        }
        else//pos
        {
            transform.Translate(-1*(Vector3.up / 400));
            //transform.position = (Vector3.up * Time.deltaTime)*-1;
            //transform.position = new Vector3(0.0f, -2f);
            height--;            
        }
        if (height == 40)
        {
            up = false;
        }
        if(height == -40)
        {
            up = true;
        }

	}
}
