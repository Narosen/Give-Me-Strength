using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//GameManager is a singleton
public class GameManager : MonoBehaviour {

	public static GameManager gm;

	public GameObject player;
	public enum GameState
	{
		Playing,
		Menu,
		Lose
	};
	public GameState gamestate = GameState.Playing;

	public Image HealthBar;
	public Image StrengthBar;
	public Image TimerBar;
	public GameObject gameCanvas;
	public GameObject gameOverCanvas;
	public GameObject MenuCanvas;
	public Text quantity;
	public AudioSource play;
	public AudioSource gameOver;

	// setup the game
	void Start () {
		Time.timeScale = 1;
		play.Play ();
		if (GetComponent<GameManager> () != null)
			gm = gameObject.GetComponent<GameManager> ();
		else
			Debug.Log ("Game Manager is missing");
		gameOverCanvas.SetActive (false);
	}

	// this is the main game event loop
	void Update () {

		quantity.text = CapsuleManager.cm.amountLeft + "";
		if (player == null) {
			player = GameObject.Find ("player");
		}
		//the operation for the health bar
		float curHealth=PlayerController.getHealth()/100f; //making the range between 0 to 1
		HealthBar.transform.localScale= new Vector3 (Mathf.Clamp (curHealth,0f,1f), HealthBar.transform.localScale.y,  HealthBar.transform.localScale.z);

		float curStrength=PlayerController.getStrength()/100f; //making the range between 0 to 1
		StrengthBar.transform.localScale= new Vector3 (Mathf.Clamp (curStrength,0f,1f), HealthBar.transform.localScale.y,  HealthBar.transform.localScale.z);

		float curTimer=PlayerController.getTimer()/100f; //making the range between 0 to 1
		TimerBar.transform.localScale= new Vector3 (Mathf.Clamp (curTimer,0f,1f), HealthBar.transform.localScale.y,  HealthBar.transform.localScale.z);

		//for pausing
		if (Input.GetKey ("escape")) {
			gm.gamestate = GameState.Menu;
		};

		switch (gamestate) {
		case GameState.Playing:
			MenuCanvas.SetActive (false);
			gameCanvas.SetActive (true);
			break;

		case GameState.Menu:
			MenuCanvas.SetActive (true);
			Time.timeScale = 0;
			break;

		case GameState.Lose:
			play.Stop ();
			gameOver.Play ();
			gameOverCanvas.SetActive (true);
			break;
		}
		
	}


}


