using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaGenerator : MonoBehaviour {

	public GameObject wall;
	float screenWidth,screenHeight;
	void Start () {

		GetScreenSize ();
		WallsGenerate ();

	}

	void GetScreenSize(){
		
		screenWidth = (float)(Camera.main.orthographicSize * 2.0 * Camera.main.aspect);
		screenHeight = (float)(Camera.main.orthographicSize * 2.0f);

	}

	void WallsGenerate(){
		
		wall.transform.localScale = new Vector2 (screenWidth, 0.01f);
		wall.name = "topWall";
		wall.tag =	"Wall";
		wall.GetComponent<BoxCollider2D> ().isTrigger = false;

		try{
			Instantiate (wall,new Vector2(0,screenHeight/2),transform.rotation,gameObject.transform);
		}
		catch{
			Debug.Log ("Wall generating error");
		}

		wall.name = "bottomWall";
		Instantiate (wall,new Vector2(0,-screenHeight/2),transform.rotation,gameObject.transform);


		wall.name = "rightWall";
		wall.transform.localScale = new Vector2 (0.04f, screenHeight);
		Instantiate (wall,new Vector2(screenWidth/2,0),transform.rotation,gameObject.transform);

		wall.name = "leftWall";
		wall.tag =	"Finish";
		wall.GetComponent<BoxCollider2D> ().isTrigger = true;
		Instantiate (wall,new Vector2(-screenWidth/2,0),transform.rotation,gameObject.transform);
	}

}
