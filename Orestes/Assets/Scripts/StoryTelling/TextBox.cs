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
	
	[HideInInspector]
	public Text textComponent;
    IEnumerator coroutine;

	[HideInInspector]
	public bool isCoroutineRunning;

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

        finished = false;
    }

    public IEnumerator Type(string text, bool clear = true, bool wait = true)
    {
        return Type(text, Color.black, clear, wait);
    }

    public IEnumerator Type(string text, Color color, bool clear = true, bool wait = true)
    {
        this.text = text;
        textComponent.color = color;
        return TypeText(clear, wait);
    }

    public void Stop()
    {
		if (isCoroutineRunning)
			StopCoroutine(coroutine);
    }

    IEnumerator TypeText(bool clear = true, bool wait = true)
    {
		isCoroutineRunning = true;

        StringBuilder sb = new StringBuilder();
		
        var lines = text.Split('\n');
		
        for (int i = 0; i < lines.Length; i++) {
            if (i != 0) {
                foreach (var c in lines[i - 1])
                    if (c != '\t')
                        sb.Append(c);
                sb.Append('\n');
            }
			
            foreach (char c in lines[i]) {
                var fast = Input.GetButton("Next");

                // Use \t as an extra delay when typing
                if (c == '\t') {
                    if (!fast)
                        yield return new WaitForSeconds(delay * 3);
                    else
                        yield return new WaitForSeconds(delay);
                    continue;
                }


                sb.Append(c);
                textComponent.text = sb.ToString();
                // Do not play spaces
                if (c != ' ')
                    // Play keystroke effect
                    audio.Play();
				
                if (!fast)
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
			
            // Clear text buffer
            // sb.Clear(); ← .NET 4
            sb.Length = 0;
        }
		
        if (wait)
            while (!Input.GetButton("Next"))
                yield return new WaitForFixedUpdate();
		
        // Clear onscreen text
        if (clear)
            textComponent.text = string.Empty;
        finished = true;

		isCoroutineRunning = false;
    }
}