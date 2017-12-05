using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
	public string levelToLoad;
	public Vector2 positionToAppear;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player") {
			GlobalObject.Instance.Position = positionToAppear;
			PlayerController.sceneLoaded = false;
			SceneManager.LoadScene (levelToLoad);
		}
	}
}
