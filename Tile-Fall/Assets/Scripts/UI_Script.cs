﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour {

    public GameObject turnControler, blueWin, redWin, draw;
    Image left, right;
    public Sprite left00, left01, left02, left03, right00, right01, right02, right03;
    int leftMove, rightMove;
	public SpriteRenderer Controls;
	float a = 0;

	// Use this for initialization
	void Start () {
        left = transform.Find("LeftSide Ui").gameObject.GetComponent<Image>();
        right = transform.Find("Rightside UI").gameObject.GetComponent<Image>();
		blueWin.SetActive (false);
		redWin.SetActive (false);
		draw.SetActive (false);
		Controls.color = new Color(Controls.color.r, Controls.color.g, Controls.color.b, 0);
    }
	
	// Update is called once per frame
	void Update () {
		updateUI();
		checkInput();
    }

	void checkInput()
	{
		if(Input.GetButton("Controls"))
		{
			if(Controls.color.a < 1)
				a += .1f;
			Controls.color = new Color(Controls.color.r, Controls.color.g, Controls.color.b, a);
		}
		else
		{
			if(Controls.color.a > 0)
				a -= .1f;
			Controls.color = new Color(Controls.color.r, Controls.color.g, Controls.color.b, a);
		}
	}
	void updateUI()
	{
		leftMove = turnControler.GetComponent<TurnController>().player1Movement;
		rightMove = turnControler.GetComponent<TurnController>().player2Movement;
		switch (leftMove) {
		case 3:
			{
				left.sprite = left00;
				break;
			}
		case 2:
			{
				left.sprite = left01;
				break;
			}
		case 1:
			{
				left.sprite = left02;
				break;
			}
		case 0:
			{
				left.sprite = left03;
				break;
			}
		}
		switch (rightMove)
		{
		case 3:
			{
				right.sprite = right00;
				break;
			}
		case 2:
			{
				right.sprite = right01;
				break;
			}
		case 1:
			{
				right.sprite = right02;
				break;
			}
		case 0:
			{
				right.sprite = right03;
				break;
			}
		}
	}

	public void Restart() {
		SceneManager.LoadScene ("Scene_1");
	}
}
