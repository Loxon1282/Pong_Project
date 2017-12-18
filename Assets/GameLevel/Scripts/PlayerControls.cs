using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
	public GameObject player;
	float playerTranslation, playerPos;
	float screenHeight,freeSpace = 0.15f;

	[Range(1.0f,10.0f)]
	public float movingSpeed =2.0f;

	[Range(0.1f,2.0f)]
	public float playerSize = 1.0f;

	void Start () {
		
		screenHeight = (float)(Camera.main.orthographicSize);

		player.transform.localScale = new Vector2 (player.transform.localScale.x, playerSize);	
	}

	void Update () {

		if(player.transform.position.y>=0)
			playerPos = player.transform.position.y + player.transform.localScale.y;
		else
			playerPos = player.transform.position.y - player.transform.localScale.y;


		player.transform.Translate (0, playerTranslation, 0);


		if ( playerPos < screenHeight-freeSpace&&Input.GetKey (KeyCode.W)|| playerPos < screenHeight-freeSpace&& Input.GetKey (KeyCode.UpArrow)) {
			
			playerTranslation = 1 * Time.deltaTime * movingSpeed;

		} 
		else if (playerPos> -screenHeight+freeSpace &&Input.GetKey (KeyCode.S)|| playerPos> -screenHeight+freeSpace&&Input.GetKey (KeyCode.DownArrow)) {
			
			playerTranslation = -1 * Time.deltaTime * movingSpeed;

		} 
		else
			playerTranslation = 0;



			

	}
}
