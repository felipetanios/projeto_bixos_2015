using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour
{
	float timeSinceStart = 0;

    // Use this for initialization
    void Start()
    {
        var textMesh = GetComponent<TextMesh>();
        if (textMesh == null)
            textMesh = GetComponentInChildren<TextMesh>();

        textMesh.text = "Score\n" + Mathf.Floor(ManagerScript.score);
    }

	void Update () {
		timeSinceStart += Time.deltaTime;

		if (Input.GetButton("Next") && timeSinceStart > 3)
			Application.LoadLevel("cena3");
	}
}