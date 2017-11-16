using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSquare : MonoBehaviour {

    public bool open = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //open = false;
	}

    void OnTriggerEnter2D (Collider2D coll)
    {
        Debug.Log("Collision");
        if (coll.gameObject.tag == "Left")
        {
            open = true;
        }
        else
        {
            open = false;
        }

    }
}
