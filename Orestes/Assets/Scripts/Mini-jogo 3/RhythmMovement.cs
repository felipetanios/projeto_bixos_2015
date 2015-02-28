using UnityEngine;
using System.Collections;

public class RhythmMovement : MonoBehaviour
{
    private static RhythmMovement instance;

	private Vector2 amountToMove;
	public float defaultSpeed = .15f;

	// Components
	public Transform groundCheck;
	public LayerMask groundMask;

	public float gravity = 30;
	private float toGoY;

    public static RhythmMovement Instance {
        get { return instance; }
    }

    void Awake()
    {
        instance = this;
    }

    void OnDestroy()
    {
        instance = null;
    }

    void Start()
    {
        RhythmBar.Instance.OnHit += OnHit;
    }
	
    // Update is called once per frame
    void FixedUpdate()
	{
		if (MovementManager.Instance.mode != MovementManager.Mode.End) {
			// Player is always on movement
			amountToMove.x = defaultSpeed;
		}
		else {
			amountToMove.x = 0;
		}

		if (!Physics2D.OverlapCircle (groundCheck.position, .02f, groundMask)) {
			toGoY -= gravity * Time.deltaTime;

			amountToMove.y = toGoY;
		}
		else {
			amountToMove.y = 0;
		}

		transform.Translate(amountToMove * Time.deltaTime);
	}

    void OnHit()
    {

    }
}
