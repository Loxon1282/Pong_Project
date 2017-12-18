using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

	public void Exit(){
		Application.Quit ();
	}
	public void LoadLevel(int levelIndex){
		SceneManager.LoadScene (levelIndex);

	}
}
