using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletText : MonoBehaviour
{
    public string title;
    public Text message;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("h");
            if (hit.collider != null)
            {
                hit.collider.enabled = false;
            }
        }*/
    }
    //doesnt work with first person controller
    private void OnMouseEnter()
    {
        Debug.Log("Look");
        Debug.Log(title);
        //message.SetActive(true);
        switch (title)
        {
            case "WormCarry":
                message.text = "I wonder what they were carrying... and why...";
                break;
            case "WormPray":
                message.text = "Looks like some kinda statue... a snake maybe?\nWhat's he doing on those knees... this is scary...";
                break;
            case "WormTemple":
                message.text = "That looks familiar... Heading straight to wherever...";
                break;
            case "torch1":
                message.text = "Good thing i have this torch, looks like these couldrons can keep it alight";
                break;
            case "torch2":
                message.text = "Better not let it run out...";
                break;
            case "drummer":
                message.text = "Drum too hard and this temple would collapse...";
                break;
            case "bones":
                message.text = "I guess theres a lot of... dead ends...";
                break;
            case "HouseBurn":
                message.text = "Looks like whatever it isnt doesnt like nosie...";
                break;
            case "lever":
                message.text = "a lever... must be hidden somewhere";
                break;
            case "door":
                message.text = "that must be the way to my brother";
                break;
            case "web":
                message.text = "I bet i can burn those webs\n must had taken years to get that big...";
                break;


            
        }
    }
    private void OnMouseExit()
    {
        message.text = "";
    }
}
