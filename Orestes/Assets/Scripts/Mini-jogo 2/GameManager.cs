using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic; 

public class GameManager : MonoBehaviour {

	[HideInInspector] public int activatedProfs;

	List<Spot> spots = new List<Spot> ();
	int totalSpots;

	private int mouseClicks;
	private float gameTime;

	// Is the game finished?
	[HideInInspector] public bool finished = false;

	// Is the prof on screen?
	[HideInInspector] public bool profOnScreen = false;

	[HideInInspector] public float score;
	public float scoreIdeal = 700;

	// Use this for initialization
	void Awake () {
		activatedProfs = GameObject.FindGameObjectsWithTag ("Prof").Length;

		GameObject[] spotsObjects;
		spotsObjects = GameObject.FindGameObjectsWithTag ("Spot");

		totalSpots = spotsObjects.Length;

		foreach (GameObject spot in spotsObjects)
			spots.Add(spot.GetComponent<Spot> ());
	}

	void Update () {
		if (!finished) {
			if (Input.GetMouseButtonDown(0))
				mouseClicks++;
			gameTime += Time.deltaTime;
			if (activatedProfs == 0)
				finished = true;
		}
		else if (finished) {
			score = scoreIdeal/(gameTime * mouseClicks) * 1000;
			Debug.Log (gameTime + " " + mouseClicks);
			enabled = false;
		}
	}

	public Spot FindSpot () {
		int chosenSpot = Random.Range (0, totalSpots);

		// Enquanto nao encontra uma posicao valida
		for (int i = 0; i < totalSpots && !spots[chosenSpot].isAvailable; i++)
			chosenSpot = Random.Range (0, totalSpots);

		spots[chosenSpot].isAvailable = false;
		return spots[chosenSpot];
	}
}