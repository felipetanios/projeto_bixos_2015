using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class InputString : MonoBehaviour
{
	public string text;
	public float delay = 0.1f;
	public bool finished = false;
	
	Text textComponent;
	IEnumerator coroutine;
	
	private static InputString instance;
	
	public static InputString Instance {
		get { return instance; }
	}
	
	void Awake()
	{
		instance = this;
	}
	
	void OnDestroy()
	{
		instance = null;
	}
	
	public void StartScript()
	{
		textComponent = GetComponent<Text>();
		coroutine = TypeText();
		
		finished = false;
		StartCoroutine(coroutine);
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
				// TODO: sound
				
				if (!Input.GetButton("Next"))
					yield return new WaitForSeconds(delay);
				else
					yield return new WaitForSeconds(delay / 4);
			}
			
			// First line shouldn't stop
			if (i != 0) {
				// Wait for confirmation
				yield return new WaitForSeconds(.35f);
				// TODO: arrow
				while (i != lines.Length - 1 && !Input.GetButton("Next"))
					yield return new WaitForFixedUpdate();
			}
			
			// Clear text
			// sb.Clear(); ← .NET 4
			if (i != lines.Length - 1)
				sb.Length = 0;
		}

		bool finishedWritten = false;
		int qt = 0;

		while (!finishedWritten) {
			// TODO: fire event
			foreach (char c in Input.inputString) {
				if (c > 64) {
					sb.Append(c);
					textComponent.text = sb.ToString();
					qt++;
				}
				else if (c == 08 && qt > 0) {
					qt--;
					textComponent.text = textComponent.text.Substring(0, textComponent.text.Length - 1);
					sb.Remove(sb.Length - 1, 1);
				}
				else if (qt > 0 && (qt > 20 || c == 32 || c == 13)) {
					finishedWritten = true;
				}
			}

			yield return null;
		}
		
		textComponent.text = string.Empty;
		finished = true;
	}
}