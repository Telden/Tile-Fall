using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Script : MonoBehaviour
{

    GameObject hitboxUp, hitboxDown, hitboxLeft, hitboxRight, turnController, target_holder;
    public LayerMask open;
    public bool isDead = false;
    public GameObject player2_sprite, player2_target;

    // Use this for initialization
    void Start()
    {
        hitboxUp = transform.Find("Up").gameObject;
        hitboxDown = transform.Find("Down").gameObject;
        hitboxLeft = transform.Find("Left").gameObject;
        hitboxRight = transform.Find("Right").gameObject;
        turnController = GameObject.Find("TurnController");
        Instantiate(player2_sprite, transform.position, Quaternion.identity);
        player2_sprite = GameObject.Find("Player2_Sprite(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        
            CheckInput();
        if (turnController.GetComponent<TurnController>().shooting && !turnController.GetComponent<TurnController>().target2Spawned)
        {
            createTarget();
        }
        if (turnController.GetComponent<TurnController>().target1Input && turnController.GetComponent<TurnController>().target2Input)
            updatePosition(player2_sprite);
        //if (isDead)
         //   Debug.Log("Player 2 Dead");
    }

    void CheckInput()
    {
        if (turnController.GetComponent<TurnController>().movement == true)
        {
            if (turnController.GetComponent<TurnController>().player2Movement > 0)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) && Physics2D.OverlapCircle(hitboxUp.transform.position, 0.4f, open))
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1.31f, transform.position.z);
                    turnController.GetComponent<TurnController>().player2Movement -= 1;
                    //Debug.Log("PLayer 2 Moved");
                }
                if (Input.GetKeyDown(KeyCode.DownArrow) && Physics2D.OverlapCircle(hitboxDown.transform.position, 0.4f, open))
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - 1.31f, transform.position.z);
                    turnController.GetComponent<TurnController>().player2Movement -= 1;
                    //Debug.Log("PLayer 2 Moved");
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow) && Physics2D.OverlapCircle(hitboxLeft.transform.position, 0.4f, open))
                {
                    transform.position = new Vector3(transform.position.x - 2.04f, transform.position.y, transform.position.z);
                    turnController.GetComponent<TurnController>().player2Movement -= 1;
                    //Debug.Log("PLayer 2 Moved");
                }
                if (Input.GetKeyDown(KeyCode.RightArrow) && Physics2D.OverlapCircle(hitboxRight.transform.position, 0.4f, open))
                {
                    transform.position = new Vector3(transform.position.x + 2.04f, transform.position.y, transform.position.z);
                    turnController.GetComponent<TurnController>().player2Movement -= 1;
                    //Debug.Log("PLayer 2 Moved");
                }
                if (Input.GetKeyDown(KeyCode.Keypad0))
                {
                    turnController.GetComponent<TurnController>().player2Movement -= 1;
                    //Debug.Log("PLayer 2 Moved");
                }
            }
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                transform.position = player2_sprite.transform.position;
                turnController.GetComponent<TurnController>().player2Movement = 3;

            }

            if (Input.GetKeyDown(KeyCode.RightShift) && turnController.GetComponent<TurnController>().player2Movement == 0)
            {
                turnController.GetComponent<TurnController>().player2Complete = true;
            }
        }
    }
    void createTarget()
    {
        //Debug.Log("Creating Target");
        if (!turnController.GetComponent<TurnController>().target2Spawned)
        {
            //Debug.Log("Instantiating target");
            Instantiate(player2_target, player2_sprite.transform.position, Quaternion.identity);
            target_holder = GameObject.Find("Player1_Target(Clone)");
            turnController.GetComponent<TurnController>().target2Spawned = true;
        }
        else
        {
            //Debug.Log("Setting to true");
            GameObject.Find("Player2_Target(Clone)").gameObject.SetActive(true);
            //player1_target = GameObject.Find("Player1_Target(Clone)");
        }
    }

    void updatePosition(GameObject player2_sprite)
    {
        player2_sprite.transform.position = transform.position;
        turnController.GetComponent<TurnController>().player2Moved = true;
    }
}