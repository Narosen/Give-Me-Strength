using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Capsule : MonoBehaviour {

	//protected float time = 10f;
	//public float strenght;
	//public float healthTaken;
	public int amount;

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.tag == "Player") {
			CapsuleManager.cm.amountLeft += amount;
			Destroy (this.gameObject);
		}
	}

}
