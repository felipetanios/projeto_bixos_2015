using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Prof : MonoBehaviour
{
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

    void Start()
    {
        isAppearing = true;
        isActivated = true;
        gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        targetSpot = GameObject.FindGameObjectWithTag("AlmostFinal");

        if (gameManagerObject)
            gameManager = gameManagerObject.GetComponent<GameManager>();

        if (targetSpot)
            target = targetSpot.GetComponent<Transform>();

        targetPosition = target.transform.position;

        totalProfs = gameManager.activatedProfs;

        StartCoroutine(InitialDelay());
    }

    void OnMouseDown()
    {
        // Don't run if there is another prof animating
        if (isActivated && !gameManager.profOnScreen) {
            // Isnt activated anymore
            isActivated = false;
            gameManager.activatedProfs--;

            // The object is still running, until the animation runs off
            gameObject.renderer.enabled = true;
            gameObject.collider2D.enabled = true;
            moving.SetBool("isAnimating", false);

            // Starts the animation + moving
            moving.SetBool("isClicked", true);
            gameManager.profOnScreen = true;

            FuckYou();
        }

    }


    void Update()
    {
        if (!isAppearing && isActivated && !gameManager.profOnScreen) {
            appears = Appears();
            StartCoroutine(appears);
        } else if (!isActivated && (Vector2.Distance(targetPosition, transform.parent.position) > 0.1)) {
            FuckYou();
        }
    }



    IEnumerator InitialDelay()
    {
        yield return new WaitForSeconds(Random.Range(0.2f, 2f));
        isAppearing = false;
    }



    IEnumerator Appears()
    {
        isAppearing = true;
        gameObject.renderer.enabled = true;
        gameObject.collider2D.enabled = true;
        moving.SetBool("isAnimating", true);

        moving.speed = ((float)totalProfs / (gameManager.activatedProfs + totalProfs));

        Spot spotScript = gameManager.FindSpot();
        if (!spotScript)
            yield break;
        transform.parent.transform.position = spotScript.spotPosition;
        transform.parent.localScale = spotScript.spotScale;
        moving.SetBool("isMirror", spotScript.isMirror);
        moving.SetBool("isWindow", spotScript.isWindow);

        float appearRange;
        if (totalProfs == gameManager.activatedProfs)
            appearRange = -Random.Range(0, 0.2f);
        else
            appearRange = Random.Range(0.5f, 1);

        yield return new WaitForSeconds((gameManager.activatedProfs / totalProfs) + appearRange);

        gameObject.renderer.enabled = false;
        gameObject.collider2D.enabled = false;
        moving.SetBool("isAnimating", false);

        gameManager.ReturnSpot(spotScript);

        yield return new WaitForSeconds((gameManager.activatedProfs / totalProfs) + Random.Range(0.5F, 1));
        isAppearing = false;
    }



    void FuckYou()
    {
        Vector3 velocidade = Vector3.zero;
        var position = Vector3.SmoothDamp(transform.parent.transform.position, targetPosition, ref velocidade, 0.2f);
        position.z = -5f;
        transform.parent.transform.position = position;
    }

    // Called from an animation event
    void BeGone()
    {
        gameManager.profOnScreen = false;
    }
}


