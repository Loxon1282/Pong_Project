using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

	GameObject player, GC;
	float playerPosY;
	float ballSpeed=10.0f;
	float startBallSpeed;
	GameController gameCtrl;


	// Use this for initialization
	void Start () {
		startBallSpeed = ballSpeed;

		player = GameObject.FindGameObjectWithTag ("Player");
		GC = GameObject.FindGameObjectWithTag ("GameController");
		gameCtrl = GC.GetComponent<GameController> ();

		StartBallMoving ();

			
	}
	void StartBallMoving(){
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (ballSpeed, Random.Range(-1.0f,1.0f));
	}
		
	void BallSpeedIncreasing(){
		ballSpeed = ballSpeed + startBallSpeed / 100;
	}

	void AddPoint(){
		gameCtrl.points++;
	}


	void OnCollisionEnter2D(Collision2D col){
		
		playerPosY = player.transform.position.y;

		float dist = gameObject.transform.position.y - playerPosY;

		if (col.gameObject.tag == "Player") {
			
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (ballSpeed, dist * 4f);

			Invoke ("BallSpeedIncreasing", 1);

			AddPoint();

		} 
	}
	void OnTriggerEnter2D(Collider2D col){
		
		if (col.gameObject.tag == "Finish") {

			gameCtrl.Invoke ("BallIsOut", 1);

		}
	}

}
