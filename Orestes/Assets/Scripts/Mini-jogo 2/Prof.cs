using UnityEngine;
using System.Collections;

public class Prof : MonoBehaviour {
	private GameObject gameManagerObject;
	private GameManager gameManager;

	private bool isAppearing = false;
	private bool isActivated = true;

	private int totalProfs;
	private 

	void Start () {
		gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");

		if (gameManagerObject)
			gameManager = gameManagerObject.GetComponent<GameManager> ();

		totalProfs = gameManager.activatedProfs;
	}

	void Update () {
		if (!isAppearing)
		{
			StartCoroutine("Appears");
		}
	}

	void OnMouseDown() {
		isActivated = false;
		gameManager.activatedProfs--;
	}

	IEnumerator Appears () {
		isAppearing = true;
		gameObject.active = true;

		transform.position = gameManager.FindSpot ();

		yield return new WaitForSeconds(gameManager.activatedProfs/totalProfs);

		isAppearing = false;
		gameObject.active = false;

		yield return new WaitForSeconds();
	}
}
