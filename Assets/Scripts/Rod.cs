using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour {

	public GameObject text;
	public int rod;

	void Start(){
		if (GlobalObject.Instance.rod1 == true && rod == 1) {
			Destroy (this.gameObject);
		}
		if (GlobalObject.Instance.rod2 == true && rod == 2) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
	
		if (coll.tag == "Player") {
			GlobalObject.Instance.hasARod = true;
			if (rod == 1)
				GlobalObject.Instance.rod1 = true;
			else if (rod == 2)
				GlobalObject.Instance.rod2 = true;
			StartCoroutine ("Noti");
			Destroy (this.gameObject, 1f);
		}
	}

	IEnumerator Noti(){
		text.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		text.SetActive (false);
	}
}
