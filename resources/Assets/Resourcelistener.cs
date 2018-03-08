using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resourcelistener : Resource {
	public Text display;
	// Use this for initialization
	void Start () {
		CurrentOwned = StartingAmount;
		display.text = StartingAmount.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (AmountChanged) {
			display.text = CurrentOwned.ToString();
			AmountChanged = false;
		}
	}
}
