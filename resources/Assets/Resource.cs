using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour {
	public int StartingAmount;
	public int CurrentOwned;

	public bool AmountChanged;
	// Use this for initialization
	void Start () {
		
	}
	public void AddAmount(int x){
		CurrentOwned += x;
		AmountChanged = true;
	}
	public void RemoveAmount(int x){
		CurrentOwned -= x;
		AmountChanged = true;
	}	
	// Update is called once per frame
	void Update () {
		
	}
}
