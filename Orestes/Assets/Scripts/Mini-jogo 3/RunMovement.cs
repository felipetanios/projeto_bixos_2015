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
	private float inputX;

	// Player handling
	private float defaultSpeed = 30f;
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

	void Start ()
	{
		defaultSpeed = 30f;
	}

	void Update ()
	{
		inputX = Input.GetAxisRaw ("Horizontal");

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
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		// Player is always on movement
		currentSpeed = defaultSpeed * Time.deltaTime;
		
		// If the button is pressed, aka it accelarates
		if (inputX != 0)
			currentSpeed = accelaration * inputX * Time.deltaTime;

		// Set the max speed
		currentSpeed = Mathf.Clamp (currentSpeed, -maxSpeed, maxSpeed);

		amountToMove.x = currentSpeed;
		
		// Set the gravity if the player isnt in the ground
		if (!grounded)
			currentYSpeed -= gravity * Time.deltaTime;

		amountToMove.y = currentYSpeed;

		//Prevents the player from skipping the camera YEA BITCH
		var dist = (transform.position - Camera.main.transform.position).z;
		
		var leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).x;
		var rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, dist)).x;
		var bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, dist)).y;
		// Keep in mind that we must consider the bottom as the ground, which is corrected by .12
		var topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, .12f, dist)).y;

		// If its on the limits, the player must move only the usual
		if (transform.position.x + amountToMove.x * Time.deltaTime < leftBorder || transform.position.x + amountToMove.x * Time.deltaTime > rightBorder)
			amountToMove.x = defaultSpeed * Time.deltaTime;

		// Finally, translates
		transform.Translate(amountToMove * Time.deltaTime);

		// Now, checks if the player desired position has passed the limits - if so, force him to stay
		transform.position = new Vector2( 
		                                 Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
		                                 Mathf.Clamp(transform.position.y, topBorder, bottomBorder));
    }
}
