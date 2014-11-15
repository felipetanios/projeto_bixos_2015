using UnityEngine;
using System.Collections;

public class Prof : MonoBehaviour {
	private GameObject gameManagerObject;
	private GameManager gameManager;
	
	private bool isAppearing;
	private bool isActivated;
	public Animator moving;

	private IEnumerator appears;
	
	private int totalProfs;

	void Start () {
		isAppearing = false;
		isActivated = true;
		gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");

		if (gameManagerObject)
			gameManager = gameManagerObject.GetComponent<GameManager> ();

		totalProfs = gameManager.activatedProfs;
	}

	void OnMouseDown() {
		Destroy (gameObject);
		
		if (appears != null)
			StopCoroutine (appears);
		
		isActivated = false;
		gameManager.activatedProfs--;
		
		gameObject.renderer.enabled = true;
		gameObject.collider2D.enabled = true;
		moving.SetBool ("isAnimating", false);
	}


	void Update () {
		if (!isAppearing && isActivated)
		{
			appears = Appears();
            StartCoroutine(appears);
		}
	}


	IEnumerator Appears () {

		isAppearing = true;
		gameObject.renderer.enabled = true;
		gameObject.collider2D.enabled = true;
		moving.SetBool ("isAnimating", true);
		if (gameManager.activatedProfs != 0)
			moving.speed = 1/(totalProfs - gameManager.activatedProfs)*(gameManager.activatedProfs/totalProfs);

		Spot spotScript = gameManager.FindSpot ();
		transform.parent.transform.position = spotScript.spotPosition;
		transform.localScale = spotScript.spotScale;

		yield return new WaitForSeconds((totalProfs - gameManager.activatedProfs)*(gameManager.activatedProfs/totalProfs)+ Random.Range(0.5F, 1));

		gameObject.renderer.enabled = false;
		gameObject.collider2D.enabled = false;
		moving.SetBool ("isAnimating", false);

		spotScript.isAvailable = true;

		yield return new WaitForSeconds((totalProfs - gameManager.activatedProfs)*(gameManager.activatedProfs/totalProfs) + Random.Range(0, 3));
		Debug.Log ("oculos");
		isAppearing = false;
	}
}
