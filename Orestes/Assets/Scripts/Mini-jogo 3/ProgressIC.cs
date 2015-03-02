using UnityEngine;
using System.Collections;

public class ProgressIC : MonoBehaviour
{
	public static ProgressIC Instance { get; private set; }

	void OnDestroy()
	{
		if (Instance == this)
			Instance = null;
	}

	private GameObject indicator;

	public delegate void OnComplete();
	
	public OnComplete Complete {
		get;
		set;
	}
	
	private float start;
	private float width;

	private float initial;
	private float total;

	private bool finished;
	
	// Use this for initialization
	void Awake()
	{
		if (Instance == null)
			Instance = this;

		indicator = transform.GetChild(0).gameObject;
		
		useGUILayout = false;
		
		guiTexture.pixelInset = new Rect {
			x = Screen.width * (4 / 20f),
			y = Screen.height - (Screen.height * (2.5f / 20f)),
			width = Screen.width * (12 / 20f),
			height = Screen.width * (1 / 40f)
		};
		
		indicator.transform.position = new Vector3(0, 0, 1);
		
		indicator.guiTexture.pixelInset = new Rect {
			x = Screen.width * (4 / 20f),
			y = Screen.height - (Screen.height * (2.5f / 20f)),
			width = Screen.width * (3 / 75f),
			height = Screen.width * (5 / 75f)
		};
		
		start = guiTexture.pixelInset.x;
		width = guiTexture.pixelInset.width - indicator.guiTexture.pixelInset.width;
	}

	void Start () {
		initial = CameraScrolling.Instance.progress;
		total = 1 - initial;
	}

	// FixedUpdate is called once per physics frame
	void FixedUpdate()
	{
		if (!finished) {
			var inset = indicator.guiTexture.pixelInset;

			inset.x = start + (width * ((CameraScrolling.Instance.progress - initial)/total));

			indicator.guiTexture.pixelInset = inset;
		}

		if (CameraScrolling.Instance.progress > 0.99f) {
			finished = true;
		}
	}
}
