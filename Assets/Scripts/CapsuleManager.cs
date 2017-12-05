using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapsuleManager : MonoBehaviour {

	public static CapsuleManager cm;
	public float strength;
	public float totalStrength;
	public float timer = 10f;
	public int amountLeft;
	public float healthTaken;
	public float finishTime;

	void Awake ()
	{
		if (cm == null)
		{
			DontDestroyOnLoad(gameObject);
			cm = this;
		}
		else if (cm != this)
		{
			Destroy (gameObject);
		}
	}

	void Update(){
		
		if (amountLeft > 0) {
			if (Input.GetKeyDown (KeyCode.Z)) {
				amountLeft -= 1;
				totalStrength += strength;
				PlayerController.setCapsuleTaken (true);
				float s = PlayerController.getStrength() + totalStrength;
				PlayerController.setStrength (s);
				PlayerController.setTimer (timer);
				finishTime = Time.time + timer;
				StartCoroutine ("TakingHealth");
			}
		}
	}

	IEnumerator TakingHealth(){
		while (finishTime > Time.time) {
			float health = PlayerController.getHealth ();
			health -= healthTaken;
			PlayerController.setHealth (health);
			PlayerController.setTimer (finishTime - Time.time);
			yield return new WaitForSeconds (1.5f);		
		}
		PlayerController.setTimer (0f);
		PlayerController.setStrength (1f);
		PlayerController.setCapsuleTaken (false);
	}
}
