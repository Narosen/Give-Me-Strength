using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour {

	public GameObject credit;
	public bool active;

	public void OnClick(){
		credit.SetActive (active);
	}
}
