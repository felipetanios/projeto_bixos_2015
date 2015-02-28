using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Canvas))]
public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Destroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public void SetUIEnabled(bool enabled)
    {
        gameObject.SetActive(enabled);
    }
}
