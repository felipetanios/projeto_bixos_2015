using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float scalingFactorX = 1;

	// Update is called once per frame
	void Update () {
		var cameraScrolling = CameraScrolling.Instance;

		transform.Translate(CameraScrolling.Instance.defaultVector.magnitude * scalingFactorX, 0, 0);
	}
}
