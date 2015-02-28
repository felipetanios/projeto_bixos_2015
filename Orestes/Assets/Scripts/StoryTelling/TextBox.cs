using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextBox : MonoBehaviour
{
    public string text;
    public float delay = 0.1f;
	public bool finished = false;

    Text textComponent;
    IEnumerator coroutine;

	private static TextBox instance;
	
	public static TextBox Instance {
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

                if (!Input.GetButton("Jump"))
                    yield return new WaitForSeconds(delay);
                else
                    yield return new WaitForSeconds(delay / 4);
            }

            // First line shouldn't stop
            if (i != 0) {
                // Wait for confirmation
                yield return new WaitForSeconds(.35f);
                // TODO: arrow
                while (!Input.GetButton("Jump"))
                    yield return new WaitForFixedUpdate();
            }

            // Clear text
            // sb.Clear(); ← .NET 4
            sb.Length = 0;
        }

        // TODO: fire event
		while (!Input.GetButton("Jump"))
			yield return new WaitForFixedUpdate();

        textComponent.text = string.Empty;
		finished = true;
    }
}