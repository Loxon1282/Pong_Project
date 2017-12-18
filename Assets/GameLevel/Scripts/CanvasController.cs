using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

	public Text points,bestScore,endBoardScore;
	public Image hpBar;
	public GameObject endBoard;
	GameController gameCtrl;
	float hpBarStartWidth;

	bool boardDown =false;
	Animator endBoardAnim;

	void Start () {
		
		gameCtrl=gameObject.GetComponent<GameController> ();
		endBoardAnim = endBoard.GetComponent<Animator> ();

		endBoardAnim.speed = 0;
		hpBarStartWidth = hpBar.rectTransform.sizeDelta.x;

		ShowHpValues ();

		
	}

	void Update () {
		
		ShowActualPoints ();
		
	}

	public void ShowEndBoard(){
		
		endBoardAnim.speed = 1;
		bestScore.text = "Najlepszy wynik: "+PlayerPrefs.GetInt ("BestScore", 0).ToString();
		endBoardScore.text = "Wynik: "+ gameCtrl.points.ToString ();

		if (!boardDown) {
			
			endBoardAnim.Play ("EndBoardAnim");
			boardDown = true;

		} 
		else {
			
			endBoardAnim.Play ("HideBoard");
			boardDown = false;
		}

	}
	void ShowActualPoints(){
		
		points.text = "Punkty: " + gameCtrl.points.ToString ();

	}
	public void ShowHpValues(){
		hpBar.rectTransform.sizeDelta = new Vector2(hpBarStartWidth * gameCtrl.lifes,hpBar.rectTransform.sizeDelta.y);
	}
}
