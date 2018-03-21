using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController : MonoBehaviour {

    public GameObject player1, player2;
    public Sprite broken;
    SpriteRenderer sr;
    GameObject playerController1, GridController;
    public bool passable = true;

    // Use this for initialization
    void Start () {
        //playerController1 = GameObject.Find("Player1");
        GridController = GameObject.Find("GridController");
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnMouseDown ()
    {
        if (gameObject.tag == "Left" && !GridController.GetComponent<GridController>().isSpawnedLeft)
        {
            Instantiate(player1, new Vector3 (transform.position.x, transform.position.y, -2), Quaternion.identity);
            GridController.GetComponent<GridController>().isSpawnedLeft = true;
            
        }
        else if (gameObject.tag == "Right" && !GridController.GetComponent<GridController>().isSpawnedRight)
        {
            Instantiate(player2, new Vector3(transform.position.x, transform.position.y, -2), Quaternion.identity);
            GridController.GetComponent<GridController>().isSpawnedRight = true;
        }
    }
    
    public void swtichSprite ()
    {

        sr.sprite = broken;

    }
}
