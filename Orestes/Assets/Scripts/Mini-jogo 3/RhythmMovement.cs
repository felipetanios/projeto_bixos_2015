using UnityEngine;
using System.Collections;

public class RhythmMovement : MonoBehaviour
{
    private static RhythmMovement instance;

	private Vector2 amountToMove;

	public float defaultSpeed = .15f;

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
		// Player is always on movement
		amountToMove.x = defaultSpeed;

		transform.Translate(amountToMove * Time.deltaTime);
	}

    void OnHit()
    {

    }
}
