using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {
	public SpriteRenderer background;
	public bool finishedFade;

	public static FadeOut Instance { get; private set; }
	
	void Awake()
	{
		if (Instance == null)
			Instance = this;
	}
	
	void OnDestroy()
	{
		if (Instance == this)
			Instance = null;
	}

	public void BeginFadeIn () {
		finishedFade = false;
		StartCoroutine (FadeTo (0, 0.5f));
	}

	public void BeginFadeOut () {
		finishedFade = false;
		StartCoroutine (FadeTo (1, 0.5f));
	}

	IEnumerator FadeTo(float alpha, float duration = .5f)
	{
		var time = 0f;
		var color = background.color;
		var initialAlpha = color.a;
		var newAlpha = initialAlpha;
		
		while (newAlpha != alpha) {
			newAlpha = Mathf.Lerp(initialAlpha, alpha, time / duration);
			color.a = newAlpha;
			
			background.color = color;
			
			time += Time.deltaTime;
			
			yield return new WaitForFixedUpdate();
		}

		finishedFade = true;
	}

}
