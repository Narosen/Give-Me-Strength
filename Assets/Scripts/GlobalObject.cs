using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalObject : MonoBehaviour {

	public static GlobalObject Instance;
	public Vector2 Position;
	public Hashtable ht;
	public Hashtable rp;
	public bool hasARod;
	public bool gate1;
	public bool gate2;
	public bool rod1;
	public bool rod2;

	void Awake ()
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
		hasARod = false;
		gate1 = false;
		gate2 = false;
		rod1 = false;
		rod2 = false;
		ht = new Hashtable ();
		ht.Add("Forest1", 0);
		ht.Add("Forest2", 0);
		ht.Add("Forest3", 0);
		ht.Add("Forest4", 0);
		ht.Add("Forest5", 0);
		ht.Add("Forest6", 0);
		ht.Add("Forest7", 0);

		rp = new Hashtable ();
		rp.Add("Forest1", 0);
		rp.Add("Forest2", 0);
		rp.Add("Forest3", 0);
		rp.Add("Forest4", 0);
		rp.Add("Forest5", 0);
		rp.Add("Forest6", 0);
		rp.Add("Forest7", 0);

	}
}
