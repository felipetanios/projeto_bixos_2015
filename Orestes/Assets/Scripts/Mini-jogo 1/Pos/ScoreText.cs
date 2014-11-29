using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        var textMesh = GetComponent<TextMesh>();
        if (textMesh == null)
            textMesh = GetComponentInChildren<TextMesh>();

        textMesh.text = "Score\n" + Mathf.Floor(ManagerScript.score);
    }
}
