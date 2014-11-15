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
		if (isAppearing)
		{

		}
	}

	void OnMouseDown() {
		isActivated = false;
		gameManager.activatedProfs--;
	}

	IEnumerator Appears () {
		transform.position = gameManager.FindSpot ();

		yield return new WaitForSeconds(gameManager.activatedProfs/totalProfs);

	}
}
