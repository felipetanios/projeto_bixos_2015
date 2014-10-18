using UnityEngine;
using System.Collections;

public class PombaMove : MonoBehaviour {

	public float speed = 10f;
	public float oscilationMagnitude = .05f;
	public float oscilationSpeed = 10f;

	public PombaShot pombaShot;

	float oscilation = 0f;

	void Update () {
		if (!pombaShot.isShooting)
		{
			oscilation += Time.deltaTime * oscilationSpeed;
			if (oscilation >= Mathf.PI * 2)
				oscilation -= Mathf.PI * 2;

			rigidbody2D.transform.Translate (new Vector2 (speed * Time.deltaTime, Mathf.Sin (oscilation) * oscilationMagnitude));
		}
	}
}