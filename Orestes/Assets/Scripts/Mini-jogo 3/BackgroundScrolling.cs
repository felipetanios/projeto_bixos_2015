using UnityEngine;
using System.Collections;

public class BackgroundScrolling : MonoBehaviour {

    public bool isTurned;
    public float scalingFactorX;

	// Update is called once per frame
	void Update () {
        var cameraScrolling = CameraScrolling.Instance;

        if (isTurned)
            transform.Translate(cameraScrolling.defaultSpeed * scalingFactorX, 0, 0);
		else
			transform.Translate(cameraScrolling.defaultVector.x * scalingFactorX,
                                cameraScrolling.defaultVector.y,
                                0);
	}
}
