using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic; 

public class GameManager : MonoBehaviour {

	[HideInInspector] public int activatedProfs;

	List<Spot> spots = new List<Spot> ();
	int totalSpots;

	// Use this for initialization
	void Awake () {
		activatedProfs = GameObject.FindGameObjectsWithTag ("Prof").Length;

		GameObject[] spotsObjects;
		spotsObjects = GameObject.FindGameObjectsWithTag ("Spot");

		totalSpots = spotsObjects.Length;

		foreach (GameObject spot in spotsObjects)
			spots.Add(spot.GetComponent<Spot> ());
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