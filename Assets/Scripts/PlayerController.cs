using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public static PlayerController player;
	public float speed = 10.0f;

	private static float Health = 100f;
	private static float Strength = 1f;
	private static float Timer = 0f;

	private static Transform transform;
	private static Collider2D coll;
	private static Vector2 move;
	public static int faceFlag = 2;
	private Rigidbody2D rb;
	private float maxDistanceForAttack = 1f;
	public LayerMask enemyMask;
	private static bool capsuleTaken = false;
	public static Animator anim;
	public static bool transformation = false;
	public static bool sceneLoaded;
	private static bool punch;

	void Awake ()
	{
		if (player == null)
		{			
			player = this;
		}
		else if (player != this)
		{
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {		
		punch = false;
		transform = GetComponent<Transform> ();
		coll = GetComponent<Collider2D> ();
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		Health = 100f;
		DontDestroyOnLoad (this.gameObject);
	}

	void Update(){
		if (Health > 0f) {
			if (sceneLoaded == false) {
				transform.position = GlobalObject.Instance.Position;
				sceneLoaded = true;
			}
			if (Timer > 0f && transformation == false) {
				StartCoroutine ("Transform", true);
			} else if (Timer <= 0f && transformation == true) {
				StartCoroutine ("Transform", false);
			}
			move.x = Input.GetAxis ("Horizontal");
			move.y = Input.GetAxis ("Vertical");
			if (move.x > 0f) {
				faceFlag = 4;
			} 
			if (move.x < 0f) {
				faceFlag = 3;
			}
			if (move.y > 0f) {
				faceFlag = 1;
			} 
			if (move.y < 0f) {
				faceFlag = 2;
			}
			anim.SetInteger ("FaceFlag", faceFlag);
			if (Input.GetButtonDown ("Punch") && punch == false) {
				punch = true;
				anim.SetBool ("Attack",punch);
				StartCoroutine("Attack"); //checking if the punch hit the enemy
			}
			if (move != Vector2.zero) {
				anim.SetBool ("Walk", true);
			} else {
				anim.SetBool ("Walk", false);
			}
		} else {
			GameManager.gm.gamestate = GameManager.GameState.Lose;
		}

	}

	IEnumerator Transform(bool t){
		transformation = t;
		if(t)
			anim.SetTrigger ("Transformation");
		else
			anim.SetTrigger ("Detransformation");
		yield return new WaitForSeconds (0.5f);
		anim.SetBool ("Trasform", transformation);
	}
	void FixedUpdate () {
		
		rb.velocity = move * speed;

	}

	IEnumerator Attack(){
		float dirX = 0f;
		float dirY = 1f;
		float dir = 1f;
		switch (faceFlag) {
		case 1:
		case 2:
			{
				maxDistanceForAttack = 1f;		
				dirX = 0f;
				dirY = 1f;
				break;
			}
		case 3:
		case 4:
			{
				maxDistanceForAttack = 1f;
				dirY = 0f;
				dirX = 1f;
				break;
			}
		}
		if(faceFlag == 2 || faceFlag == 3){
			dir = -1f;
		}
		RaycastHit2D hit=Physics2D.Raycast(transform.position, new Vector2(dirX*dir,dirY*dir), maxDistanceForAttack, enemyMask);	
		Debug.DrawLine (transform.position, transform.position + new Vector3 (dirX * dir * maxDistanceForAttack, dirY * dir * maxDistanceForAttack, 0.0f));
		if (hit.collider != null && hit.collider.tag == "Enemy") {
			hit.transform.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
			Enemy enemy = hit.transform.gameObject.GetComponent<Enemy> ();
			if(capsuleTaken)
				enemy.BeingHit(Random.Range (Strength,Strength+5f),faceFlag);
			else
				enemy.BeingHit(Random.Range (Strength,Strength+1f),faceFlag);
		}
		yield return new WaitForSeconds (0.1f);
		punch = false;
		anim.SetBool ("Attack",punch);
	}

	//getters
	public static float getHealth(){
		return Health;
	}

	public static float getStrength(){
		return Strength;
	}

	public static float getTimer(){
		return Timer;
	}

	public static Vector3 getPosition(){
		return transform.position;
	}

	public static Collider2D getCollider(){
		return coll;
	}

	public static bool getCapsuleTaken(){
		return capsuleTaken;
	}

	public static Transform getTransform(){
		return transform;
	}

	//setters
	public static void setHealth(float h){
		Health = h;
	}

	public static void setStrength(float s){
		Strength = s;
	}

	public static void setTimer(float t){
		Timer = t;
	}

	public static void setCapsuleTaken(bool c){
		capsuleTaken = c;
	}

	//void OnDrawGizmos() {
		//Gizmos.color = Color.yellow;
		//Gizmos.DrawLine(transform.position, transform.position + new Vector3(dirX*dir*maxDistanceForAttack,dirY*dir*maxDistanceForAttack,0.0f));
	//}
}
