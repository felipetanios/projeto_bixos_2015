using UnityEngine;
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

	public Vector3 FindSpot () {
		int choosedSpot = Random.Range (0, totalSpots - 1);

		// Enquanto nao encontra uma posicao valida
//		while (!spots[choosedSpot].isAvailable)
//			choosedSpot = Random.Range (0, totalSpots - 1);

		spots[choosedSpot].isAvailable = false;
		return spots[choosedSpot].spotPosition;
	}
}