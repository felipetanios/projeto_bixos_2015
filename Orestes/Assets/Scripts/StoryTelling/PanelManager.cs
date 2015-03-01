using UnityEngine;
using System.Collections;

public class PanelManager : MonoBehaviour
{
	
    public static PanelManager Instance { get; private set; }

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

    public void EnableUI()
    {
        CanvasManager.Instance.SetUIEnabled(true);
    }

    public void CreateNewText(string myText)
    {
		TextBox.Instance.Stop ();
        TextBox.Instance.text = myText;

        TextBox.Instance.StartScript();
    }

	public void CreateNewInput (string myText) {
		InputString.Instance.Stop ();
		InputString.Instance.text = myText;
		
		InputString.Instance.StartScript ();
	}
}
