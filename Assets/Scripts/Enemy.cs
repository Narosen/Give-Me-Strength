using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

	public float playerCheckRaduis = 3.0f;
	public float playerNearRaduis = 3.0f;
	public LayerMask playerLayer;
	protected int faceFlag = 1;
	protected bool playerSpoted = false;
	protected Collider2D playerTouching;

	public float health;
	public float minDis;
	public float speed;
	public float Damage;
	public float TimetakenAttack;

	public bool isDeath = false;
	protected bool playerAttack;
	protected Animator anim;

	protected int colTag = 0;

	// Use this for initialization
	protected void Start () {
		anim = GetComponent<Animator> ();
	}

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

	protected void Update(){
		
		if (health > 0) {
			
			if (playerSpoted) {
				if (Mathf.Abs(PlayerController.getPosition ().x) > Mathf.Abs(PlayerController.getPosition ().y)) {
					if (PlayerController.getPosition ().x < transform.position.x) {
						faceFlag = 3;
					} else if (PlayerController.getPosition ().x > transform.position.x) {
						faceFlag = 4;
					}
				} else {
					if (PlayerController.getPosition ().y < transform.position.y) {
						faceFlag = 1;
					} else if (PlayerController.getPosition ().y > transform.position.y) {
						faceFlag = 2;
					}
				}
				anim.SetInteger ("FaceFlag", faceFlag);
			} 
		} else {
			anim.SetFloat ("Health", health);
			death ();
		}
	}


	public void BeingHit(float hitPoints, int direction){
		health -= hitPoints;
		StartCoroutine ("GotHit",direction);
	}

	public IEnumerator GotHit(int direction){
		playerAttack = true;
		anim.SetBool ("gotHit", playerAttack);
		if (PlayerController.getCapsuleTaken ()) {
			float attackForce = 5f;
			switch (direction) {
			case 1:
				{
					gameObject.GetComponent<Rigidbody2D> ().velocity += Vector2.up * attackForce;
					break;
				}
			case 2:
				{
					gameObject.GetComponent<Rigidbody2D> ().velocity += Vector2.down * attackForce;
					break;
				}
			case 3:
				{
					gameObject.GetComponent<Rigidbody2D> ().velocity += Vector2.left * attackForce;
					break;
				}
			case 4:
				{
					gameObject.GetComponent<Rigidbody2D> ().velocity += Vector2.right * attackForce;
					break;
				}
			}
		}
		yield return new WaitForSeconds (0.1f);
		playerAttack = false;
		anim.SetBool ("gotHit", playerAttack);
		gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		yield return null;
	}


	public IEnumerator Attack(){
		anim.SetBool ("Player Spotted", true);
		colTag = 1;
		float h = PlayerController.getHealth (); 
		PlayerController.setHealth( h - Damage);
		yield return new WaitForSeconds(TimetakenAttack);
		colTag = 0;
		anim.SetBool ("Player Spotted", false);

	}

	protected void death(){
		GetComponent<Collider2D> ().enabled = false;
		Destroy (gameObject,0.5f);
	}

	//getter

	public float getHealth(){
		return health;
	}

	//setter

	public void setHealth(float h){
		health = h;

	}

	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, playerNearRaduis);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, playerCheckRaduis);
	}

}
