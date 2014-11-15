using UnityEngine;
using System.Collections;
using System;

public class MouseManager : MonoBehaviour
{

    public Texture2D normalCursorTexture;
    public Texture2D intermediateCursorTexture;
    public Texture2D pressedCursorTexture;
    public GameObject mouseCollider;

    private Vector2 hotspot;
    private IEnumerator mouseAnimation;
    private bool pressed;

    // Use this for initialization
    void Start()
    {
        hotspot = new Vector2(normalCursorTexture.width / 2, normalCursorTexture.height / 2);
        Cursor.SetCursor(normalCursorTexture, hotspot, CursorMode.Auto);
    }
	
    // Update is called once per frame
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
        mouseCollider.transform.position = new Vector3(mousePosition.x, mousePosition.y, mouseCollider.transform.position.z);
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
