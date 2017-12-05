using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndUI : MonoBehaviour {

	public GameObject UI;
	public AudioSource audio;

	void OnTriggerEnter2D(Collider2D coll){
		Time.timeScale = 0;
		GameManager.gm.play.Stop ();
		audio.Play ();
		if (coll.tag == "Player") {
			UI.SetActive (true);		
		}
	}
}
