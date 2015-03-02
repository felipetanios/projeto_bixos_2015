using UnityEngine;
using System.Collections;

public class EndMovement : MonoBehaviour {
	public static EndMovement Instance { get; private set; }
	
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

		transform.Translate(amountToMove * Time.deltaTime);
	}
}