using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour {

    public GameObject gridSquareLeft, gridSquareRight, divider, camera;
    public int height, width;
    GameObject [,] gridSquaresLeft; 
    GameObject [,] gridSquaresRight;
    public Vector3 [,] gridPositionsLeft;
    public Vector3 [,] gridPositionsRight;
	float magicNumberWidth = 2.03f;
	float magicNumberHeight = 1.31f;
    public bool isSpawnedLeft = false, isSpawnedRight = false;


    // Use this for initialization
    void Start() {

        
        gridPositionsLeft = new Vector3[height, width];
        gridSquaresLeft = new GameObject[height, width];
        gridPositionsRight = new Vector3[height, width];
        gridSquaresRight = new GameObject[height, width];



        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
            {
				gridPositionsLeft[i, j] = new Vector3(i * magicNumberWidth, j*magicNumberHeight, 0);
                gridSquaresLeft[i, j] = Instantiate(gridSquareLeft, gridPositionsLeft[i, j], Quaternion.identity);
            } 
		Instantiate(divider, new Vector3(width * magicNumberWidth, (height * magicNumberHeight) / 2, 0), Quaternion.identity);
        camera.transform.position = new Vector3(divider.transform.position.x - 1.02f, divider.transform.position.y-0.515f, -3f);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
				gridPositionsRight[i, j] = new Vector3((i + width) * magicNumberWidth, j * magicNumberHeight, 0);
                gridSquaresRight[i, j] = Instantiate(gridSquareRight, gridPositionsRight[i, j], Quaternion.identity);
            }
        }


    }
}
