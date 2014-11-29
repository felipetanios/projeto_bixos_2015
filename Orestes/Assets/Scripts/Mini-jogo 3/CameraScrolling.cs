using UnityEngine;
using System.Collections;

public class CameraScrolling : MonoBehaviour
{
    private static readonly Vector3 runVector = new Vector3(0.5f, 0.0881635f, 0);
    private static readonly Vector3 rhythmVector = new Vector3(0.8f, 0.1410615f, 0);
    private static readonly float runSpeed = runVector.magnitude;
    private static readonly float rhythmSpeed = rhythmVector.magnitude;

    public Vector3 defaultVector;
    public float defaultSpeed;

    private static CameraScrolling instance;

    public static CameraScrolling Instance {
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

    // Use this for initialization
    void Start()
    {
	
    }

    // Update is called once per frame
    void Update()
    {
        if (MovementManager.Instance.mode == MovementManager.Mode.Run) {
            defaultVector = runVector * Time.deltaTime;
            defaultSpeed = runSpeed * Time.deltaTime;
            transform.Translate(defaultVector);
        } else { // MovementManager.Instance.mode == MovementManager.Mode.Rhythm
            defaultVector = rhythmVector * Time.deltaTime;
            defaultSpeed = rhythmSpeed * Time.deltaTime;
            transform.Translate(defaultVector);
        }
    }
}
