using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


public class PlayerManager: MonoBehaviour {

	public Resource[] Resources;
	[HideInInspector]public GameObject m_Instance;
	public Transform spawnpoint;
	public Color Color;
	//List<Unit> Units;


	void Awake () {
		//Units = new List<Unit> ();
	}
}
