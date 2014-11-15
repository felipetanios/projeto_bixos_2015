using UnityEngine;
using System.Collections;

public class Spot : MonoBehaviour {

	[HideInInspector] public Vector3 spotPosition;
	[HideInInspector] public bool isAvailable = true;

	void Start () {
		spotPosition = this.transform.position;
	}
}
