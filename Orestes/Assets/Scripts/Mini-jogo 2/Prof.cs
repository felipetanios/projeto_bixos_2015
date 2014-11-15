using UnityEngine;
using System.Collections;

public class Prof : MonoBehaviour {
	private GameObject gameManagerObject;
	private GameManager gameManager;
	
	private bool isAppearing = false;
	private bool isActivated = true;
	public Animator moving;
	
	private int totalProfs;

	void Start () {
		gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");

		if (gameManagerObject)
			gameManager = gameManagerObject.GetComponent<GameManager> ();

		totalProfs = gameManager.activatedProfs;
	}

	void Update () {
		if (!isAppearing)
		{
            StartCoroutine(Appears());
		}
	}

	void OnMouseDown() {
		isActivated = false;
		gameManager.activatedProfs--;
	}

	IEnumerator Appears () {
		isAppearing = true;
		gameObject.renderer.enabled = true;
		gameObject.collider2D.enabled = true;
		isAppearing = true;

		moving.SetTrigger ("isAnimating");
		moving.speed = 1/(gameManager.activatedProfs / totalProfs);
		
		Spot spotScript = gameManager.FindSpot ();
		transform.position = spotScript.spotPosition;
		transform.localScale = spotScript.spotScale;

		yield return new WaitForSeconds(gameManager.activatedProfs/totalProfs);

		gameObject.renderer.enabled = false;
		gameObject.collider2D.enabled = false;
		moving.ResetTrigger ("isAnimating");

		spotScript.isAvailable = true;

		yield return new WaitForSeconds(gameManager.activatedProfs/totalProfs);

		isAppearing = false;
	}
}
