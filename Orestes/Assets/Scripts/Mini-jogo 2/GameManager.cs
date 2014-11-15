using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[HideInInspector] public int activatedProfs;

	// Use this for initialization
	void Awake () {
		activatedProfs = GameObject.FindGameObjectsWithTag ("Prof").Length;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector3 FindSpot () {
		return new Vector3(0, 0, 0);
	}
}