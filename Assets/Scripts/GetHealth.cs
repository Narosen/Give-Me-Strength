using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHealth : MonoBehaviour {

	public float health;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player") {
			PlayerController.setHealth (PlayerController.getHealth () + health);
			Destroy (this.gameObject);
		}
	}
}
