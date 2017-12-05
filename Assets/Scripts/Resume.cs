using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour {

	public void OnClick(){
		Time.timeScale = 1;
		GameManager.gm.gamestate = GameManager.GameState.Playing;
	}
}
