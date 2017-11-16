using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject gridController;
    public GameObject player1, player2;
    public bool isSpawnedLeft = false;
    public bool isSpawnedRight = false;

    GameObject player1HitboxUp, player1HitboxDown, player1HitboxLeft, player1HitboxRight;
    GameObject player2HitboxUp, player2HitboxDown, player2HitboxLeft, player2HitboxRight;

    // Use this for initialization
    void Start () {
        //player1HitboxUp = player1.transform.Find("Up").gameObject;
        //player1HitboxDown = player1.transform.Find("Down").gameObject;
        //player1HitboxLeft = player1.transform.Find("Left").gameObject;
        //player1HitboxRight = player1.transform.Find("Right").gameObject;

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void CheckInput ()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Debug.Log("key pressed");
            //if (player1HitboxLeft.GetComponent<CheckSquare>().open)
            //{
                player1.transform.position = new Vector3(player1.transform.position.x - 1, player1.transform.position.y, transform.position.z);
            //}

        }
    }

    
}
