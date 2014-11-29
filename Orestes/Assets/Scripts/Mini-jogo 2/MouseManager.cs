using UnityEngine;
using System.Collections;
using System;

public class MouseManager : MonoBehaviour
{
    static MouseManager instance;

    public Texture2D normalCursorTexture;
    public Texture2D intermediateCursorTexture;
    public Texture2D pressedCursorTexture;
    public GameObject mouseCollider;

    private Vector2 hotspot;
    private IEnumerator mouseAnimation;

    public static MouseManager Instance {
        get {
            return instance;
        }
    }

    public bool IsMouseNear(Spot spot)
    {
        return mouseCollider.collider.bounds.Intersects(spot.collider2D.bounds);
    }

    void Awake()
    {
        instance = this;
        hotspot = new Vector2(normalCursorTexture.width / 2, normalCursorTexture.height / 2);
        Cursor.SetCursor(normalCursorTexture, hotspot, CursorMode.Auto);
    }

    void OnDestroy()
    {
        instance = null;
    }
	
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (mouseAnimation != null)
                StopCoroutine(mouseAnimation);

            mouseAnimation = pressAnimation();
            StartCoroutine(mouseAnimation);
        } else if (Input.GetMouseButtonUp(0)) {
            if (mouseAnimation != null)
                StopCoroutine(mouseAnimation);

            mouseAnimation = unpressAnimation();
            StartCoroutine(mouseAnimation);
        }

        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        mouseCollider.transform.position = mousePosition;
    }

    IEnumerator pressAnimation()
    {
        Cursor.SetCursor(intermediateCursorTexture, hotspot, CursorMode.Auto);
        yield return new WaitForSeconds(0.05f);
        Cursor.SetCursor(pressedCursorTexture, hotspot, CursorMode.Auto);
    }

    IEnumerator unpressAnimation()
    {
        Cursor.SetCursor(intermediateCursorTexture, hotspot, CursorMode.Auto);
        yield return new WaitForSeconds(0.05f);
        Cursor.SetCursor(normalCursorTexture, hotspot, CursorMode.Auto);
    }
}
