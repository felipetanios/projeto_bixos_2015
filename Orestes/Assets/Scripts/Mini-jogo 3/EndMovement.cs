using UnityEngine;
using System.Collections;

public class EndMovement : MonoBehaviour {
	public static EndMovement Instance { get; private set; }

	// Components
	public Transform groundCheck;
	public LayerMask groundMask;
	
	public float gravity = 30;
	private float toGoY;

	void Awake()
	{
		if (Instance == null)
			Instance = this;
	}
	
	void OnDestroy()
	{
		if (Instance == this)
			Instance = null;
	}
	
	public float defaultSpeed = 0.001f;
	private Vector2 amountToMove;

	void FixedUpdate () {
		amountToMove.x = defaultSpeed;

		if (!Physics2D.OverlapCircle (groundCheck.position, .02f, groundMask)) {
			toGoY -= gravity * Time.deltaTime;
			
			amountToMove.y = toGoY;
		}
		else {
			amountToMove.y = 0;
		}

		transform.Translate(amountToMove * Time.deltaTime);
	}
}