using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveorNo : MonoBehaviour {

	public string button;
	public GameObject objectToSetActive;
	bool touched;

	void Start(){
		touched = false;
	}

	void Update(){
		if (Input.GetButtonDown (button)) {
			objectToSetActive.SetActive (false);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player" && touched == false) {
			touched = true;
			objectToSetActive.SetActive (true);
		}
	}

}
