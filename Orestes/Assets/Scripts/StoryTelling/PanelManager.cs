using UnityEngine;
using System.Collections;

public class PanelManager : MonoBehaviour {
	public GameObject textBox;

	private static PanelManager instance;
	public static PanelManager Instance {
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

	public void CreateNewText (string myText) {
		TextBox.Instance.text = myText;

		TextBox.Instance.StartScript ();
	}

	public void CreateNewInput (string myText) {
		InputString.Instance.text = myText;
		
		InputString.Instance.StartScript ();
	}
}
