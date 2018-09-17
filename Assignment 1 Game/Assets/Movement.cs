using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Rigidbody rb;

    public float speed = 5f;
    public float mainSpeed = 100.0f; //regular speed
    public float shiftAdd = 250.0f; //multiplied by how long shift is held.  Basically running
    public float maxShift = 1000.0f; //Maximum speed when holdin gshift
    public float camSens = 0.25f; //How sensitive it with mouse
    public Vector3 lastMouse; //kind of in the middle of the screen, rather than at the top (play)
    public float totalRun = 1.0f;

    // Use this for initialization
    void Start () {


        rb = GetComponent<Rigidbody>();

        //GameObject[] objs = GameObject.FindGameObjectsWithTag("level1");
        //GameObject.FindGameObjectWithTag("level1");

        //GameObject.FindGameObjectWithTag("level1").SetActive(false);
        //foreach (GameObject o in objs) {
        //    o.SetActive(false);
        //}
        //objs[0].SetActive(false);

    }

    void Update()
    {


        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            //rb.AddForce(0,0,speed,ForceMode.Force);
            rb.velocity = new Vector3(0, 0, speed);
            //pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -speed, ForceMode.Force);
            //pos.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(speed, 0, 0, ForceMode.Force);
            //pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-speed, 0, 0, ForceMode.Force);
            //pos.x -= speed * Time.deltaTime;
        }



        transform.position = pos;

        //Cursor.lockState = CursorLockMode.Confined;
        //Screen.lockCursor = true;


        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
        //Mouse  camera angle done.  

        if(lastMouse.x > 2000)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x , transform.eulerAngles.y);
        }

    }
}