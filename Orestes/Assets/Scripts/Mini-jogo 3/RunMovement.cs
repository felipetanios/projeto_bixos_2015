using UnityEngine;
using System.Collections;

public class RunMovement : MonoBehaviour
{
    private static RunMovement instance;

    public static RunMovement Instance {
        get { return instance; }
    }

	public float currentSpeed;

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
	
    }
}
