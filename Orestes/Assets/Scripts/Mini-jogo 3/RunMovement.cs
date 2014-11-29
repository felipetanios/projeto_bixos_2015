using UnityEngine;
using System.Collections;

public class RunMovement : MonoBehaviour
{
    private static RunMovement instance;

    public static RunMovement Instance {
        get { return instance; }
    }

	[HideInInspector] public float currentSpeed;

	public float maxSpeed = 50;
	public float defaultSpeed = 20;
	public float accelaration = 40;

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
    }
}
