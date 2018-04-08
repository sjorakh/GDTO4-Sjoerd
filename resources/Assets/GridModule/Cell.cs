using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int X;
    public int Y;
	public Color Select = Color.blue;
	Color currentColor;
	public Color unselectedColor = Color.gray;
	public bool selected = false;
	Mesh test;
	public Unit unit;

	void Update ()
	{
		if (!selected) {
			currentColor = unselectedColor; 
		} else {
			currentColor = Select;
		}
		MeshRenderer render = this.gameObject.GetComponentInChildren<MeshRenderer> ();
		Material mat = new Material (Shader.Find("Standard"));
		mat.color = currentColor;
		render.material = mat;
	}
}
