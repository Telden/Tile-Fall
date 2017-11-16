using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour {
    public GameObject player1, player2, gridController, player1_sprite, player2_sprite;
    public bool movement = true;
    public bool shooting = false;
    public int player1Movement = 3, player2Movement = 3;
    public bool player1Complete = false, player2Complete = false;
    public bool target1Spawned = false, target2Spawned = false;
    public bool target1Input = false, target2Input = false;
    public bool player1Moved = false, player2Moved = false;
    public bool player1Finished = false, player2Finished = false;

    // Use this for initialization
    void Start () {
        


	}

    // Update is called once per frame
    void Update()
    {
       if(player1Complete && player2Complete)
        {
            movement = false;
            shooting = true;
        }
       if(player1Finished && player2Finished)
        {
            
            checkWinCondition();
            resetGame();
        }
    }

   void resetGame()
    {
        //Debug.Log("Resetting Game");
        movement = true;
        target1Input = false;
        target2Input = false;
        shooting = false;
        player1Complete = false; player2Complete = false;
        target1Spawned = false; target2Spawned = false;
        target1Input = false; target2Input = false;
        player1Moved = false; player2Moved = false;
        player1Finished = false; player2Finished = false;
        player1Movement = 3;
        player2Movement = 3;

    }
    void checkWinCondition()
    {
        Debug.Log("Checking Win condition");
        if (GameObject.Find("Player1(Clone)").GetComponent<Player1Script>().isDead && GameObject.Find("Player2(Clone)").GetComponent<Player2Script>().isDead )
        {
			GameObject.Find ("Canvas").GetComponent<UI_Script> ().draw.SetActive (true);
			Debug.Log("Draw");
            //Draw Implementation
        }

        else if (GameObject.Find("Player1(Clone)").GetComponent<Player1Script>().isDead)
        {
			GameObject.Find ("Canvas").GetComponent<UI_Script> ().redWin.SetActive (true);
            Debug.Log("Player 2 Wins");
            //Win Screen for player 2
        }

        else if (GameObject.Find("Player2(Clone)").GetComponent<Player2Script>().isDead)
        {
			GameObject.Find ("Canvas").GetComponent<UI_Script> ().blueWin.SetActive (true);
            Debug.Log("PLayer 1 Wins");
            //Win condition for player 1
        }

    }
}
