using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RhythmMovement.Instance.enabled = false;
		RhythmBar.Instance.gameObject.SetActive(false);

		Time.timeScale = 0;
	}

	void OnMouseDown () {
		Time.timeScale = 1;
		MovementManager.Instance.ChangeMode (MovementManager.Mode.Rhythm);

		GameObject.Destroy (gameObject);
	}

	void Update () {

	}
}
