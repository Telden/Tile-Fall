using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_shooting : MonoBehaviour {
    GameObject hitboxUp, hitboxDown, hitboxLeft, hitboxRight, turnController;
    public LayerMask open, player;
    bool movement = true;
    Collider2D coll;
    // Use this for initialization
    void Start () {
        hitboxUp = transform.Find("Up").gameObject;
        hitboxDown = transform.Find("Down").gameObject;
        hitboxLeft = transform.Find("Left").gameObject;
        hitboxRight = transform.Find("Right").gameObject;
        turnController = GameObject.Find("TurnController");
    }
	
	// Update is called once per frame
	void Update () {
        checkInput();
        if (turnController.GetComponent<TurnController>().player1Moved && turnController.GetComponent<TurnController>().player2Moved)
            CheckSquare();
	}

    void checkInput()
    {
        if (turnController.GetComponent<TurnController>().shooting && movement)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && Physics2D.OverlapCircle(hitboxUp.transform.position, 0.4f, open))
            {
               transform.position = new Vector3(transform.position.x, transform.position.y + 1.31f, transform.position.z);

            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && Physics2D.OverlapCircle(hitboxDown.transform.position, 0.4f, open))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 1.31f, transform.position.z);

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && Physics2D.OverlapCircle(hitboxLeft.transform.position, 0.4f, open))
            {
                transform.position = new Vector3(transform.position.x - 2.04f, transform.position.y, transform.position.z);

            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && Physics2D.OverlapCircle(hitboxRight.transform.position, 0.4f, open))
            {
                transform.position = new Vector3(transform.position.x + 2.04f, transform.position.y, transform.position.z);

            }

            if(Input.GetKeyDown(KeyCode.RightShift))
                {
                movement = false;
                turnController.GetComponent<TurnController>().target1Input = true;
            }
        }
    }
    void CheckSquare()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.4f, player))
        {
            //Debug.Log("Killed PLayer");
            //Kill player 1
            GameObject.Find("Player1(Clone)").GetComponent<Player1Script>().isDead = true;
            turnController.GetComponent<TurnController>().player1Finished = true;
        }
        if (Physics2D.OverlapCircle(transform.position, 0.4f, open))
        {
            //Debug.Log("Destroyed Tile");
            //destroy the tile
            coll = Physics2D.OverlapCircle(transform.position, 0.5f);

            if(coll.gameObject.layer == 8)
            {
                Debug.Log("Tile Destroyed");
                coll.gameObject.layer = 10;
                coll.gameObject.GetComponent<SquareController>().swtichSprite();
            }

            turnController.GetComponent<TurnController>().player1Finished = true;
            Destroy(gameObject);

        }

    }
}
