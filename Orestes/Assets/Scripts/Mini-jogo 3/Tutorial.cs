using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public GameObject progressIC;

	// Use this for initialization
	void Start () {
		RhythmMovement.Instance.enabled = false;
		RhythmBar.Instance.gameObject.SetActive(false);
		RunMovement.Instance.enabled = false;

		Time.timeScale = 0;
	}

	void OnMouseDown () {
		Time.timeScale = 1;
		progressIC.SetActive (true);
		
		MovementManager.Instance.ChangeMode (MovementManager.Mode.Rhythm);

		Destroy (gameObject);
		gameObject.SetActive(false);
	}

	void Update () {

	}
}
