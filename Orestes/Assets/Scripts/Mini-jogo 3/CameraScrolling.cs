using UnityEngine;
using System.Collections;

public class CameraScrolling : MonoBehaviour
{
    private static readonly Vector3 runVector = new Vector3(1.94f, 0.37f, 0);
    private static readonly float runSpeed = runVector.magnitude;

	// I just use the rhythm speed as some scale of the run speed...
	// private static readonly Vector3 rhythmVector = new Vector3(0.8f, 0.1410615f, 0);
	// private static readonly float rhythmSpeed = rhythmVector.magnitude;

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

    // Update is called once per frame
    void Update()
    {
        if (MovementManager.Instance.mode == MovementManager.Mode.Run) {
            defaultVector = runVector * Time.deltaTime * 0.3f;
            defaultSpeed = runSpeed * 0.5f;
            transform.Translate(defaultVector);
        } else { // MovementManager.Instance.mode == MovementManager.Mode.Rhythm
			defaultVector = runVector * 0.05f * Time.deltaTime;
			defaultSpeed = runSpeed * 0.1f;
            transform.Translate(defaultVector);
        }
    }
}
