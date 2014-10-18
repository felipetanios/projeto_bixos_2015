using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	
	public float speed = 0.0f;
	public float maxspeed = 15.0f;
	public float acceleration = 20f;
	public float arrasto = 1.2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// FAST FAST! SCREW U TIME, NOW IM SUPER DUPER FAST.
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			Time.timeScale = 1.25f;
		}
		if (Input.GetKeyUp(KeyCode.UpArrow))
		{
			Time.timeScale = 1f;
		}

		// Easter egg
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Time.timeScale = 2f;
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			Time.timeScale = 1f;
		}

		float move = Input.GetAxisRaw("Horizontal");

		speed += acceleration * Time.deltaTime * move;
		
		speed = Mathf.Clamp (speed, -maxspeed, maxspeed);
				
		transform.Translate (Vector2.right * Time.deltaTime * speed);

		// Garante que o arrasto seja realizado adequadamente
		if (move == 0 && speed != 0) {
					if (speed > 0) {			
							speed += arrasto * Mathf.Sign (speed) * (-1);
							if (speed < 0) {
									speed = 0;
							}
					}
					else {			
						speed += arrasto * Mathf.Sign (speed) * (-1);
						if (speed > 0) {
							speed = 0;
						}
					}
			}

		if (transform.position.x < -7.11f) {
			transform.position = new Vector3 (-7.11f, transform.position.y, transform.position.z);
			speed = 0f;
		}
		if (transform.position.x > 7f) {
			transform.position = new Vector3 (7f, transform.position.y, transform.position.z);
			speed = 0f;
		}
	}
	
}	