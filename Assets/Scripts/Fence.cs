using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour {
	
	[SerializeField] private GameObject sceneCanvas;
	public GameObject open;
	public int gate;

	void Start(){
		if (GlobalObject.Instance.gate1 == true && gate == 1) {
			open.SetActive (true);
			this.gameObject.SetActive (false);
		}
		if (GlobalObject.Instance.gate2 == true && gate == 2) {
			open.SetActive (true);
			this.gameObject.SetActive (false);
		}
	}

	void Update(){
		if (Input.GetKeyDown ("space")) {
			Time.timeScale = 1;
			sceneCanvas.SetActive (false);
		}

	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.collider.tag == "Player" && GlobalObject.Instance.hasARod == false) {
			Time.timeScale = 0;
			sceneCanvas.SetActive (true);
		}

		if (coll.collider.tag == "Player" && GlobalObject.Instance.hasARod == true) {
			GlobalObject.Instance.hasARod = false;
			if(gate == 1)
				GlobalObject.Instance.gate1 = true;
			else if(gate == 2)
				GlobalObject.Instance.gate2 = true;
			open.SetActive (true);
			this.gameObject.SetActive (false);
		}
	}
}
