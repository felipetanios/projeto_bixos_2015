using UnityEngine;
using System.Collections;

public class JesusSeMexe : MonoBehaviour {
	
	public float speed = 0.0f;
	public float maxspeed = 15.0f;
	public float accelerationMax = 2.0f;
	public float accZoeiro = 3.8f;
	public float acceleration = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxisRaw("Horizontal");
		
		acceleration += accZoeiro * move;
		
		acceleration = Mathf.Clamp (acceleration, -accelerationMax, accelerationMax);
		
		speed += acceleration * Time.deltaTime;
		
		speed = Mathf.Clamp (speed, -maxspeed, maxspeed);
		
		transform.Translate (Vector2.right * Time.deltaTime * speed);
	}
	
}	