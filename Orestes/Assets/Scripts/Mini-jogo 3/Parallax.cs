using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public float spaceGoneInX;
	public float speedInX;
	private bool isOnCollider;
	// Use this for initialization
	void Start () {
		isOnCollider = false;
		spaceGoneInX = 20.0F;
		speedInX = 0.09F;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isOnCollider) {
			transform.position = new Vector3(transform.position.x + spaceGoneInX, transform.position.y, transform.position.z);
			isOnCollider = false;
		} 
		else {
			transform.Translate (-speedInX, 0, 0);
		}
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		isOnCollider = true;
	}
}
