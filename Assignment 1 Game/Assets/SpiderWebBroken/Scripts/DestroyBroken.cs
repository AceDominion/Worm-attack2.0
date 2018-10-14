using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBroken : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {

        Destroy(gameObject, 2f);

    }
}
