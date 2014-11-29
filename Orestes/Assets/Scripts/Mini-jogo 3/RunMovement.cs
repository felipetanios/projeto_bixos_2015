using UnityEngine;
using System.Collections;

public class RunMovement : MonoBehaviour
{
    private static RunMovement instance;

    public static RunMovement Instance {
        get { return instance; }
    }

	[HideInInspector] public float currentSpeed;

	[HideInInspector] public float defaultSpeed = 20;
	public float maxSpeed = 50;
	public float accelaration = 40;

	public float gravity = 20;
	public float jumpSpeed = 35;

	private bool grounded = false;
	public Transform groundCheck;

    void Awake()
    {
        instance = this;
    }

    void OnDestroy()
    {
        instance = null;
    }

    // Use this for initialization
    void Start()
    {
    }
	
    // Update is called once per frame
    void Update()
    {
		currentSpeed = defaultSpeed * Time.deltaTime;

		float move = Input.GetAxisRaw ("Horizontal");

		if (move != 0)
			currentSpeed = accelaration * move * Time.deltaTime;

		currentSpeed = Mathf.Clamp (currentSpeed, -maxSpeed, maxSpeed);

		transform.Translate(Vector2.right * Time.deltaTime * currentSpeed);

		grounded = Physics2D.OverlapCircle (groundCheck.transform.position, .02f, 10);

		// Set the gravity if the player isnt in the ground
		if (!grounded) 
		{
			transform.Translate(-Vector2.up * Time.deltaTime * gravity);
		}
		else if (Input.GetButtonDown("Jump"))
		{
			transform.Translate(Vector2.up * Time.deltaTime * jumpSpeed);
		}
    }
}
