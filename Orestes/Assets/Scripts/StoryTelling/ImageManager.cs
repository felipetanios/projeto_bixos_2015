using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageManager : MonoBehaviour
{

    private Image image;

    public static ImageManager Instance { get; private set; }

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

    /// <summary>
    /// Fades this image object to the specified alpha value.
    /// </summary>
    /// <remarks>
    /// Must consume Enumarator from Coroutine to have any effect.
    /// </remarks>
    public IEnumerator FadeTo(float alpha, float duration = .5f)
    {
        var time = 0f;
        var color = image.color;
        var initialAlpha = color.a;
        var newAlpha = initialAlpha;

        while (newAlpha != alpha) {
            newAlpha = Mathf.Lerp(initialAlpha, alpha, time / duration);
            color.a = newAlpha;

            image.color = color;

            time += Time.deltaTime;

            yield return new WaitForFixedUpdate();
        }
    }

    /// <summary>
    /// Immediate version of <see cref="FadeTo"/>.
    /// </summary>
    public void AlphaTo(float alpha)
    {
        var color = image.color;
        color.a = alpha;
        image.color = color;
    }

    public void SwitchImage(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
