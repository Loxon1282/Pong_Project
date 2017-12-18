using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public int points;
	public int lifes = 3;
	public GameObject ball;
	GameObject gameArea;
	CanvasController canvControl;
	GameObject ballInGame;

	void Awake(){
		canvControl = GetComponent<CanvasController> ();
		try{
		gameArea = GameObject.FindGameObjectWithTag ("GameArea");
		}
		catch{
			Debug.Log ("Can't find GameArea");
		}
	}

	void Start () {
		
		Time.timeScale = 1;
		points = 0;
		lifes = 3;
		Invoke ("ThrowTheBall", 1);
		canvControl.Invoke("ShowHpValues",1);
	
	}

	void Update () {
		Debug.Log (points);
		
	}
	void BallIsOut(){
		lifes--;
		canvControl.ShowHpValues ();
		if (lifes > 0) {
			Invoke ("ThrowTheBall", 1);
		} else
			GameOver ();
			
	}

	void ThrowTheBall(){
		
		if (ballInGame != null) {
			Destroy (ballInGame);
		}

		ballInGame=Instantiate (ball,gameArea.transform);

	}

	void GameOver(){
		if(points>PlayerPrefs.GetInt("BestScore",0))
		PlayerPrefs.SetInt ("BestScore", points);
		
		Time.timeScale = 0;
		canvControl.ShowEndBoard ();
	}

	public void PlayAgain(){
		canvControl.ShowEndBoard ();
		Start ();
	}
}
