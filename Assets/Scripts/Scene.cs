using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene : MonoBehaviour {

	[SerializeField] private GameObject sceneCanvas;
	public Text entry;
	public TextAsset textFile;
	public string forLevel;
	private bool active;

	void Start(){
		active = false;
		if (GlobalObject.Instance.ht [forLevel].Equals(1)) {
			Destroy (this.gameObject);
		}
	}


	void Update(){
		if (Input.GetKeyDown ("space") && active == true) {
			Time.timeScale = 1;
			sceneCanvas.SetActive (false);
			GlobalObject.Instance.ht [forLevel] = 1;
			Destroy (this.gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player") {
			active = true;
			Time.timeScale = 0;
			sceneCanvas.SetActive (true);
			entry.text = textFile.text;
		}
	}
}
