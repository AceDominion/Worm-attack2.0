using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebTransparency : MonoBehaviour
{

    /**/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.Equals("RigidBodyFPSController"))
        {
            Destroy(gameObject);
        }
    }


}
