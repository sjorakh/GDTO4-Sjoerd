using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
	public int x, y;
	public bool occupied;
	public GameObject tile;

	public Tile(int x, int y){
		this.x = x;
		this.y = y;
	}
	public void instantiateObj(){
		tile = Instantiate (tile, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
	}

	public void occupy(){
		occupied = true;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
