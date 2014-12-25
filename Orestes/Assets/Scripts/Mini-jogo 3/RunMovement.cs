using UnityEngine;
using System.Collections;

public class RunMovement : MonoBehaviour
{
    private static RunMovement instance;
    public static RunMovement Instance {
        get { return instance; }
    }

	// System
	[HideInInspector] public float currentSpeed; // The speed the parallax should get
	private float currentYSpeed;
	private Vector2 amountToMove;

	// Player handling
	public float defaultSpeed = 20;
	public float maxSpeed = 50;
	public float accelaration = 40;
	public float gravity = 20;
	public float jumpHeight = 500;
	public float doubleJumpHeight = 20;

	// States
	private bool grounded = false;
	private bool isJumping = false;
	private bool doubleJump;

	// Components
	public Transform groundCheck;
	public LayerMask groundMask;

	float yVelocity = 0;

    void Awake()
    {
        instance = this;
    }

    void OnDestroy()
    {
        instance = null;
    }
	
    // Update is called once per frame
    void FixedUpdate()
    {
		// Player is always on movement
		currentSpeed = defaultSpeed * Time.deltaTime;

		float move = Input.GetAxisRaw ("Horizontal");
		
		// If the button is pressed, aka it accelarates
		if (move != 0)
			currentSpeed = accelaration * move * Time.deltaTime;

		// Set the max speed
		currentSpeed = Mathf.Clamp (currentSpeed, -maxSpeed, maxSpeed);

		amountToMove.x = currentSpeed;

		// Is he grounded?
		grounded = Physics2D.OverlapCircle (groundCheck.position, .02f, groundMask);

		// If he is grounded and wants to jump
		if (grounded && Input.GetButtonDown("Jump"))
		{
			currentYSpeed = jumpHeight;
			isJumping = true;
			doubleJump = true;
		}
		// Doublejump!?
		else if (isJumping && doubleJump && Input.GetButtonDown("Jump"))
		{
			currentYSpeed = jumpHeight;
			doubleJump = false;
		}
		// Or if he just reached the ground
		else if (grounded && currentYSpeed < 0)
		{
			currentYSpeed = 0;
			isJumping = false;
			doubleJump = false;
		}
		
		// Set the gravity if the player isnt in the ground
		if (!grounded)
			currentYSpeed -= gravity * Time.deltaTime;

		amountToMove.y = currentYSpeed;

		// Finally, translates
		transform.Translate(amountToMove * Time.deltaTime);
    }
}
