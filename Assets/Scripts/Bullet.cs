using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float damage;
	public float speed;
	private bool start = false;
	private Vector2 direction;

	void Start(){
		
		start = false;
	}

	void Update(){
		if (start == false) {
			start = true;
			direction = PlayerController.getPosition () - transform.position;
		}
		transform.Translate (direction * Time.deltaTime * speed);
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player") {
			float h = PlayerController.getHealth ();
			PlayerController.setHealth (h - damage);
			Destroy (this.gameObject);
		}
	}
}
