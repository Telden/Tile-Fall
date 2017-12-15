using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer1Anim : MonoBehaviour {
	
	ParticleSystem mExplosion;
	// Use this for initialization
	void Start () {
		mExplosion = transform.GetChild(0).GetComponent<ParticleSystem>();
		mExplosion.Stop();
	}
	
	public void resetAnim()
	{
		GameObject.Find("Player1_Sprite(Clone)").GetComponent<Animator>().SetBool("isFiring", false);
	}
	public void playExplosion()
	{
		//this.GetComponent<Animator>().StopPlayback();
		mExplosion.Play();
		Invoke("stopParticleSystem", 0.5f);
	}

	void stopParticleSystem()
	{
		mExplosion.Pause();
	}
}
