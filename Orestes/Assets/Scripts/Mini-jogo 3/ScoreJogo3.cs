using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Canvas))]
public class ScoreJogo3 : MonoBehaviour
{

    public float TimesHit { get; set; }
    public float MissedHits { get; set; }

    public static ScoreJogo3 Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    void Destroy()
    {
        Instance = null;
    }

    int CalculateScore()
    {
        float ideal = 1000;
        float score = ideal - 5*(TimesHit*TimesHit) - 2*MissedHits;

        return (int) Mathf.Max(score, 0);
    }

    public void Show()
    {
        GameObject.FindWithTag("Progress").SetActive(false);
        GetComponent<Canvas>().enabled = true;
        gameObject.SetActive(true);
        Time.timeScale = 0;
        var text = GetComponentInChildren<Text>();
        if (text != null)
            text.text = CalculateScore().ToString();
    }

    public void Continue()
    {
        GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
        MovementManager.Instance.ChangeMode(MovementManager.Mode.End);
    }

}
