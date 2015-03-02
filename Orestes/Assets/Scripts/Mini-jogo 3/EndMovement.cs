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
	
	public float defaultSpeed = 30f;
	private Vector2 amountToMove;

	void fixedUpdate () {
		amountToMove.x = defaultSpeed;

		transform.Translate(amountToMove * Time.deltaTime);
	}
}