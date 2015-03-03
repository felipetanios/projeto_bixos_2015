using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
	public GameObject fadeOutObject;
    public GameObject creditosPanel;

	void Start () {
		StartCoroutine(Scene());
	}

    public void Iniciar()
    {
		StartCoroutine(FadeOutScene());
    }

    public void MostraCreditos(bool mostra)
    {
        creditosPanel.SetActive(mostra);
    }

    public void Muta()
    {
        var music = Camera.main.GetComponent<AudioSource>();
        music.mute = !music.mute;
    }

	
	private IEnumerator Scene()
	{
		yield return new WaitForSeconds (2);

		FadeOut.Instance.BeginFadeIn ();
		while (FadeOut.Instance.finishedFade == false)
			yield return null;
		
		var color = Color.black;
		color.a = 0;
		fadeOutObject.GetComponent<SpriteRenderer> ().color = color;
	}

	private IEnumerator FadeOutScene() {
		FadeOut.Instance.BeginFadeOut();
		while (FadeOut.Instance.finishedFade == false)
			yield return null;

		Application.LoadLevel("cena1");
	}

}
