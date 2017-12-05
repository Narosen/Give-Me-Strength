using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour {

	public string level;

	public void ChangeLevel(){

		if (PlayerController.player != null && GlobalObject.Instance != null && CapsuleManager.cm != null) {
			PlayerController.setHealth (100f);
			PlayerController.setTimer (0f);
			PlayerController.setCapsuleTaken (false);
			PlayerController.transformation = false;
			PlayerController.sceneLoaded = false;
			PlayerController.anim.SetTrigger ("Detransformation");
			PlayerController.anim.SetBool ("Trasform", false);
			GlobalObject.Instance.hasARod = false;
			GlobalObject.Instance.gate1 = false;
			GlobalObject.Instance.gate2 = false;
			GlobalObject.Instance.rod1 = false;
			GlobalObject.Instance.rod2 = false;
			GlobalObject.Instance.Position = new Vector2(0f,-6f);

			GlobalObject.Instance.rp ["Forest1"] = 0;
			GlobalObject.Instance.rp ["Forest2"] = 0;
			GlobalObject.Instance.rp ["Forest3"] = 0;
			GlobalObject.Instance.rp ["Forest4"] = 0;
			GlobalObject.Instance.rp ["Forest5"] = 0;
			GlobalObject.Instance.rp ["Forest6"] = 0;
			GlobalObject.Instance.rp ["Forest7"] = 0;

			GlobalObject.Instance.ht ["Forest1"] = 0;
			GlobalObject.Instance.ht ["Forest2"] = 0;
			GlobalObject.Instance.ht ["Forest3"] = 0;
			GlobalObject.Instance.ht ["Forest4"] = 0;
			GlobalObject.Instance.ht ["Forest5"] = 0;
			GlobalObject.Instance.ht ["Forest6"] = 0;
			GlobalObject.Instance.ht ["Forest7"] = 0;


			CapsuleManager.cm.totalStrength = 0f;
			CapsuleManager.cm.amountLeft = 0;
			CapsuleManager.cm.finishTime = 0f;
		}

		SceneManager.LoadScene (level);
	}
}
