using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionShooter : Enemy {

	public GameObject bullet;

	protected void FixedUpdate () {
		playerSpoted = Physics2D.OverlapCircle (transform.position, playerCheckRaduis, playerLayer);
		playerTouching = Physics2D.OverlapCircle (transform.position, playerNearRaduis, playerLayer);
		if (playerTouching) {
			GetComponent<Rigidbody2D> ().isKinematic = true;
		} else {
			GetComponent<Rigidbody2D> ().isKinematic = false;
		}
		if (playerSpoted) {
			if (GetComponent<Collider2D> ().Distance (PlayerController.getCollider ()).distance > minDis && playerAttack == false) { 
				transform.position = Vector2.MoveTowards (transform.position, PlayerController.getPosition (), speed * Time.deltaTime);
				anim.SetBool ("Walk", true);
			} else {
				anim.SetBool ("Walk", false);
				if (colTag == 0) {
					StartCoroutine (Attack ());
				}

			}
		}
	}

	public IEnumerator Attack(){
		colTag = 1;
		anim.SetBool ("Player Spotted", true);
		Instantiate (bullet, transform.position, transform.rotation);
		yield return new WaitForSeconds(TimetakenAttack);
		anim.SetBool ("Player Spotted", false);
		colTag = 0;

	}
}
