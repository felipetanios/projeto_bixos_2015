﻿using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text), typeof(AudioSource))]
public class TextBox : MonoBehaviour
{
    [TextArea(3, 5)]
    public string text;
    public float delay = 0.075f;
    [HideInInspector]
    public bool finished = false;

    Text textComponent;
    IEnumerator coroutine;

    public static TextBox Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        textComponent = GetComponent<Text>();
    }

    void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public void StartScript()
    {
        coroutine = TypeText();
        StartCoroutine(coroutine);
    }

    public IEnumerator Type(string text)
    {
        return Type(text, Color.black);
    }

    public IEnumerator Type(string text, Color color)
    {
        this.text = text;
        textComponent.color = color;
        return TypeText();
    }

    public void Stop()
    {
        StopCoroutine(coroutine);
    }

    IEnumerator TypeText()
    {
        StringBuilder sb = new StringBuilder();

        var lines = text.Split('\n');

        for (int i = 0; i < lines.Length; i++) {
            if (i != 0) {
                sb.Append(lines[i - 1]);
                sb.Append('\n');
            }

            foreach (char c in lines[i]) {
                sb.Append(c);
                textComponent.text = sb.ToString();
                // Play keystroke effect
                audio.Play();

                if (!Input.GetButton("Next"))
                    yield return new WaitForSeconds(delay);
                else
                    yield return new WaitForSeconds(delay / 3);
            }

            // First line shouldn't stop
            if (i != 0) {
                // Wait for confirmation
                yield return new WaitForSeconds(.35f);
                // TODO: arrow
                while (!Input.GetButton("Next"))
                    yield return new WaitForFixedUpdate();
            }
        }

        // TODO: fire event
        while (!Input.GetButton("Jump"))
            yield return new WaitForFixedUpdate();

		// Clear text
		// sb.Clear(); ← .NET 4
		sb.Length = 0;

        textComponent.text = string.Empty;
        finished = true;
    }
}