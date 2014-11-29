using UnityEngine;
using System.Collections;

public class Prof : MonoBehaviour {
	private GameObject gameManagerObject;
	private GameManager gameManager;
	
	private bool isAppearing;
	private bool isActivated;
	public Animator moving;
	private GameObject targetSpot;
	private Transform target;
	private Vector3 targetPosition;

	private IEnumerator appears;
	
	private int totalProfs;

	void Start () {
		isAppearing = true;
		isActivated = true;
		gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
		targetSpot = GameObject.FindGameObjectWithTag ("AlmostFinal");

		if (gameManagerObject)
			gameManager = gameManagerObject.GetComponent<GameManager> ();

		if (targetSpot)
			target = targetSpot.GetComponent<Transform> ();

		targetPosition = target.transform.position;

		totalProfs = gameManager.activatedProfs;

		StartCoroutine(InitialDelay ());
	}

	void OnMouseDown() {
		if (isActivated) {
			// If the coroutine is running - it should be
			if (appears != null)
				StopCoroutine (appears);
		
			// Isnt activated anymore
			isActivated = false;
			gameManager.activatedProfs--;

			// The object is still running, until the animation runs off
			gameObject.renderer.enabled = true;
			gameObject.collider2D.enabled = true;
			moving.SetBool ("isAnimating", false);

			// Changes the layer (just in case)
			transform.position = new Vector3 (transform.position.x, transform.position.y, 2.0F);

			// Starts the animation + moving
			moving.SetBool ("isClicked", true);
			gameManager.profOnScreen = true;

			FuckYou ();
			StartCoroutine(BeGone ());
		}

	}


	void Update () {
		if (!isAppearing && isActivated && !gameManager.profOnScreen)
		{
			appears = Appears();
            StartCoroutine(appears);
		}
		else if (!isActivated && (targetPosition.x - transform.parent.transform.position.x > 0.1)) {
			FuckYou();
		}
	}



	IEnumerator InitialDelay () 
	{
		yield return new WaitForSeconds (Random.Range (0.2f, 2f));
		isAppearing = false;
	}



	IEnumerator Appears () 
	{
		isAppearing = true;
		gameObject.renderer.enabled = true;
		gameObject.collider2D.enabled = true;
		moving.SetBool ("isAnimating", true);

		moving.speed = ((float)totalProfs / (gameManager.activatedProfs + totalProfs)) ;

		Spot spotScript = gameManager.FindSpot ();
		transform.parent.transform.position = spotScript.spotPosition;
		transform.parent.localScale = spotScript.spotScale;
		moving.SetBool ("isMirror", spotScript.isMirror);
		moving.SetBool ("isWindow", spotScript.isWindow);

		float appearRange;
		if (totalProfs == gameManager.activatedProfs)
			appearRange = - Random.Range (0, 0.2f);
		else 
			appearRange = Random.Range (0.5f, 1);

		yield return new WaitForSeconds((gameManager.activatedProfs / totalProfs) + appearRange);

		gameObject.renderer.enabled = false;
		gameObject.collider2D.enabled = false;
		moving.SetBool ("isAnimating", false);

		spotScript.isAvailable = true;

		yield return new WaitForSeconds((gameManager.activatedProfs / totalProfs) + Random.Range (0.5F, 1));
		isAppearing = false;
	}



	void FuckYou ()
	{
		Vector3 velocidade = Vector3.zero;
		transform.parent.transform.position = Vector3.SmoothDamp (transform.parent.transform.position, targetPosition, ref velocidade, 0.2f);
		transform.parent.transform.position = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y, -5.0f);

	//	float targetPositionX = Mathf.SmoothDamp (transform.parent.transform.position.x , target.position.x, ref velocidade, 0.3F, Time.deltaTime);
	//	float targetPositionY = Mathf.SmoothDamp (transform.parent.transform.position.y, targetPosition.y , ref velocidade, 0.3F, Time.deltaTime);
	//	transform.position = new Vector3(targetPositionX, targetPositionY, -3.0f);
	}

	IEnumerator BeGone () 
	{
		yield return new WaitForSeconds (5);
		gameManager.profOnScreen = false;
	}
}


