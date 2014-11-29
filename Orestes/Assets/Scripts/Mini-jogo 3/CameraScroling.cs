using UnityEngine;
using System.Collections;

public class CameraScroling : MonoBehaviour {

	public float defaultSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (RunMovement.Instance.enabled) {
			transform.Translate (0.5f * Time.deltaTime, 0, 0);
			defaultSpeed = 0.5f;
		}
		else if (!(RunMovement.Instance.enabled))
		{
			transform.Translate (0.8f * Time.deltaTime, 0, 0);
			defaultSpeed = 0.8f;
		}
	}
}
