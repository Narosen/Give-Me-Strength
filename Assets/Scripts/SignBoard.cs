using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignBoard : MonoBehaviour {

	[SerializeField] private GameObject sceneCanvas;
	public Text notice;
	public TextAsset textFile;


	void Update(){
		if (Input.GetKeyDown ("space")) {
			Time.timeScale = 1;
			sceneCanvas.SetActive (false);
		}

	}
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player") {
			Time.timeScale = 0;
			sceneCanvas.SetActive (true);
			notice.text = textFile.text;
		}
	}
}
