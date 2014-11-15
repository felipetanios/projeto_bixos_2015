using UnityEngine;
using System.Collections;

public class Spot : MonoBehaviour {

	[HideInInspector] public Vector3 spotPosition;
	[HideInInspector] public Vector3 spotScale;
	[HideInInspector] public bool isAvailable;

	void Start () {
		spotPosition = this.transform.position;
		spotScale = this.transform.localScale;
		isAvailable = true;
	}
}
