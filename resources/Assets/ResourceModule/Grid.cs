using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour {

	public int Rows;
	public int Columns;
	public List<Tile> Tiles;

	// Use this for initialization
	void Start () {
		Tiles = new List<Tile> ();
		for (int x = 0; x < Rows; x++) {
			for (int y = 0; y < Columns; y++) {
				Tiles.Add(new Tile(x, y));
			}
		}
	}
	public void occupyTile(int x, int y){
		foreach (Tile tile in Tiles) {
			if (tile.x == x && tile.y == y) {
				tile.occupy();
			}
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
	public Tile getUnOccupied(){
		foreach (Tile Tile in Tiles) {
			if (Tile.occupied) {
				return Tile;
			}
		}
		return null;
	}

	public Tile getTile(int x, int y){
		foreach (Tile Tile in Tiles) {
			if (Tile.x == x && Tile.y == y) {
				return Tile;
			}
		}
		return null;
	}
}
