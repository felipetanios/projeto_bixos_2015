using UnityEngine;
using System.Collections;

public class CocoMove : MonoBehaviour {

	public float speed = 8f;
	bool grounded = false;

	public Animator splash;
	
	// Update is called once per frame
	void Update () {
		if (!grounded)
			rigidbody2D.transform.Translate (new Vector2 (0, -speed * Time.deltaTime));
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ground") {
			grounded = true;
			StartCoroutine("Die");
		}
		else if (other.tag == "Player") {
			Destroy (gameObject);
		}
	}

	IEnumerator Die () {
		splash.SetTrigger ("Dead");
		Destroy(rigidbody2D);
		collider2D.enabled = false;

		yield return new WaitForSeconds(1.8f);
		Destroy (gameObject);
	}
}