using UnityEngine;
using System.Collections;

public class CocoMove : MonoBehaviour {

	public float speed = 8f;

	void Start () {
		StartCoroutine("Die");
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.transform.Translate (new Vector2 (0, -speed * Time.deltaTime));
	}

	IEnumerator Die () {
		yield return new WaitForSeconds(2f);
		Destroy (gameObject);
	}
}