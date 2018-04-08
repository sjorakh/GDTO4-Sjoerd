using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour {

	public Cell CurrentUnitSelection;
	Cell PrevUnitSelection;
	Cell CurrentMoveSelection;
	Cell PrevMoveSelection;
	public UnitFactory[] units;
	public Map map;
	RaycastHit hit;
	public bool moving = false;
	public RawImage playerColor;
	// Use this for initialization
	void Start () {
		PrevMoveSelection = null;
		PrevUnitSelection = null;
		CurrentMoveSelection = null;
		CurrentUnitSelection = null;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonUp(0)) 
		{
			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject.name.Contains("Quad"))
				{
					if (CurrentUnitSelection != null) {
						PrevUnitSelection = CurrentUnitSelection;
					}
					CurrentUnitSelection = hit.collider.gameObject.GetComponentInParent<Cell>();
					CurrentUnitSelection.Select = playerColor.color;
					CurrentUnitSelection.selected = true;
					PrevUnitSelection.selected = false;
					for (int i = 0; i < units.Length; i++) {
						units [i].x = CurrentUnitSelection.X;
						units [i].y = CurrentUnitSelection.Y;
					}
				}
			}
		} 
		else if (Input.GetMouseButtonUp(1)) 
		{
			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject.name.Contains("Quad"))
				{
					Debug.Log ("hello");
					if (CurrentMoveSelection != null) {
						PrevMoveSelection = CurrentMoveSelection;
					}
					CurrentMoveSelection = hit.collider.gameObject.GetComponentInParent<Cell>();
					CurrentMoveSelection.selected = false;
					PrevMoveSelection.selected = false;
				}
			}
		} 
		if (moving) {
			if (CurrentMoveSelection != null && CurrentUnitSelection != null && CurrentUnitSelection.unit != null) {
				if (CurrentMoveSelection.X - CurrentUnitSelection.X <= CurrentUnitSelection.unit.MoveCount && CurrentMoveSelection.Y - CurrentUnitSelection.Y <= CurrentUnitSelection.unit.MoveCount) {
					if (CurrentMoveSelection.unit != null) {
						return;
					} else {
						CurrentUnitSelection.unit.transform.SetParent (CurrentMoveSelection.transform, false);
						CurrentMoveSelection.unit = CurrentUnitSelection.unit;
						CurrentUnitSelection.unit = null;
						CurrentMoveSelection = null;
						return;
					}

				}else {
					Debug.Log ("can't move unit");
				}
				moving = false;
			}
		}
	}
	public void ToggleMoving(){
		moving = !moving;
	}
}
