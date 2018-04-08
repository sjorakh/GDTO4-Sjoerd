using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour {
	public GameObject m_PlayerPrefab;
	public PlayerManager[] m_Players;
	public RawImage playerColor;
	public Selection selec;
	public int currentPlayer = 0;
	int prevPlayer = 0;


	void Start () {
		playerColor.color = m_Players [currentPlayer].Color;
	}
	
	// Update is called once per frame
	void Update () {	
	}

	public void ChangePlayer(){
		//m_Players[currentPlayer];
		if (currentPlayer < m_Players.Length-1) {
			prevPlayer = currentPlayer;
			currentPlayer++;
			playerColor.color = m_Players[currentPlayer].Color;

		}
		else {
			prevPlayer = currentPlayer;
			currentPlayer = 0;
			playerColor.color = m_Players[currentPlayer].Color;
		}
		m_Players[currentPlayer].gameObject.SetActive(true);
		m_Players[prevPlayer].gameObject.SetActive(false);
		for (int i = 0; i < m_Players[currentPlayer].Resources.Length; i++) {
			m_Players [currentPlayer].Resources [i].AddAmount (20);
		}


		selec.CurrentUnitSelection.selected = false;
	}
	
}
