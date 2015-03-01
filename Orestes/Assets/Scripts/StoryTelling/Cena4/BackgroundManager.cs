using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : ImageManager
{

    public static new BackgroundManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        image = GetComponent<Image>();
    }

    void Destroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public IEnumerator PanTo(float dest, float duration)
    {
        var time = 0f;
        var position = image.rectTransform.anchoredPosition;
        var initialPos = position.x;
        var newPos = initialPos;

        while (!Mathf.Approximately(newPos, dest)) {
            newPos = Mathf.Lerp(initialPos, dest, time / duration);
            position.x = newPos;
            image.rectTransform.anchoredPosition = position;

            time += Time.deltaTime;

            yield return new WaitForFixedUpdate();
        }
    }
}