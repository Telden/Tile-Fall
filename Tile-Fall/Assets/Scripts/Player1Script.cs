using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Script : MonoBehaviour {

    //public GameObject gridController;
    public GameObject player1_sprite, player1_target, target_holder;
    GameObject hitboxUp, hitboxDown, hitboxLeft, hitboxRight, turnController;
    //public bool isSpawnedLeft = false;
    public LayerMask open;
    public bool isDead = false;

	int upCooldown = 20;
	int downCooldown = 20;
	int leftCooldown = 20;
	int rightCooldown = 20;
	int coolDownReset = 10;

    // Use this for initialization
    void Start () {
        hitboxUp = transform.Find("Up").gameObject;
        hitboxDown = transform.Find("Down").gameObject;
        hitboxLeft = transform.Find("Left").gameObject;
        hitboxRight = transform.Find("Right").gameObject;
        turnController = GameObject.Find("TurnController");
        Instantiate(player1_sprite, transform.position, Quaternion.identity);
        player1_sprite = GameObject.Find("Player1_Sprite(Clone)");

       
       
    }
	
	// Update is called once per frame
	void Update () {
       
            CheckInput();
        if(turnController.GetComponent<TurnController>().shooting && !turnController.GetComponent<TurnController>().target1Spawned)
        {
            createTarget();
        }
        if (turnController.GetComponent<TurnController>().target1Input && turnController.GetComponent<TurnController>().target2Input)
            updatePosition(player1_sprite);
       // if (isDead)
           // Debug.Log("Player 1 Dead");

    }

    void CheckInput()
    {
        if (turnController.GetComponent<TurnController>().movement == true)
        {
            if (turnController.GetComponent<TurnController>().player1Movement > 0)
            {
				if ((Input.GetKeyDown(KeyCode.W) || Input.GetAxis("xBox1 Vertical") == 1) && Physics2D.OverlapCircle(hitboxUp.transform.position, 0.4f, open) && upCooldown == 0)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1.31f, transform.position.z);
                    turnController.GetComponent<TurnController>().player1Movement -= 1;
					upCooldown = coolDownReset;
                    //Debug.Log("PLayer 1 Moved");
                }
				else
				{
					if(upCooldown > 0)
						upCooldown -=1;
				}
				if ((Input.GetKeyDown(KeyCode.S) || Input.GetAxis("xBox1 Vertical") == -1) && Physics2D.OverlapCircle(hitboxDown.transform.position, 0.4f, open) && downCooldown == 0)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - 1.31f, transform.position.z);
                    turnController.GetComponent<TurnController>().player1Movement -= 1;
					downCooldown = coolDownReset;
                    //Debug.Log("PLayer 1 Moved");
                }
				else
				{
					if(downCooldown > 0)
						downCooldown -=1;
				}
				if ((Input.GetKeyDown(KeyCode.A) || Input.GetAxis("xBox1 Horizontal") == -1 )&& Physics2D.OverlapCircle(hitboxLeft.transform.position, 0.4f, open) && leftCooldown == 0)
                {
                    transform.position = new Vector3(transform.position.x - 2.04f, transform.position.y, transform.position.z);
                    turnController.GetComponent<TurnController>().player1Movement -= 1;
					leftCooldown = coolDownReset;
                    //Debug.Log("PLayer 1 Moved");
                }
				else
				{
					if(leftCooldown > 0)
						leftCooldown -=1;
				}
				if ((Input.GetKeyDown(KeyCode.D) || Input.GetAxis("xBox1 Horizontal") == 1) && Physics2D.OverlapCircle(hitboxRight.transform.position, 0.4f, open) && rightCooldown == 0)
                {
                    transform.position = new Vector3(transform.position.x + 2.04f, transform.position.y, transform.position.z);
                    turnController.GetComponent<TurnController>().player1Movement -= 1;
					rightCooldown = coolDownReset;
                    //Debug.Log("PLayer 1 Moved");
                }
				else
				{
					if(rightCooldown > 0)
						rightCooldown -=1;
				}
				if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonUp("xBox1 Stay"))
                {
                    turnController.GetComponent<TurnController>().player1Movement -= 1;
                }
            }
			if (Input.GetKeyDown(KeyCode.R) ||  Input.GetButtonUp("xBox1 Reset"))
            {
                transform.position = new Vector3(player1_sprite.transform.position.x, player1_sprite.transform.position.y, player1_sprite.transform.position.z);
                turnController.GetComponent<TurnController>().player1Movement = 3;
            }

			if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonUp("xBox1 Input")) && turnController.GetComponent<TurnController>().player1Movement == 0)
            {
                turnController.GetComponent<TurnController>().player1Complete = true;
            }
        }

     
    }

    void createTarget()
    {
        //Debug.Log("Creating Target");
        if(!turnController.GetComponent<TurnController>().target1Spawned)
        {
            //Debug.Log("Instantiating target");
            Instantiate(player1_target, player1_sprite.transform.position, Quaternion.identity);
            target_holder = GameObject.Find("Player1_Target(Clone)");
            turnController.GetComponent<TurnController>().target1Spawned = true;
        }
        else
        {
            Debug.Log("Setting to true");
            GameObject.Find("Player1_Target(Clone)").gameObject.SetActive(true);
            //player1_target = GameObject.Find("Player1_Target(Clone)");
        }
    }
    void updatePosition(GameObject player1_sprite)
    {
        player1_sprite.transform.position = transform.position;
        turnController.GetComponent<TurnController>().player1Moved = true;
    }
 }
