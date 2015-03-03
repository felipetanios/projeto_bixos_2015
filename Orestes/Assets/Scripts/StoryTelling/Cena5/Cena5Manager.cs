using UnityEngine;
using System.Collections;

public class Cena5Manager : MonoBehaviour {
	public static Cena5Manager Instance { get; private set; }

	public Color green;
	public GameObject FadeOutObject;

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

	// Use this for initialization
	void Start () {
		StartCoroutine ("Scene5");
	}

	IEnumerator Scene5 () {
		FadeOut.Instance.BeginFadeIn ();
		while (FadeOut.Instance.finishedFade == false)
			yield return null;

		var color = Color.white;
		color.a = 0;
		FadeOutObject.GetComponent<SpriteRenderer> ().color = color;

		PanelManager.Instance.EnableUI();

		
		TextBox.Instance.textComponent.color = green;
		PanelManager.Instance.CreateNewText ("A reserva do GAMUX para essa sala já acabou bixo, você está atrasado.");

		while (TextBox.Instance.finished == false) {
			yield return null;
		}
		
		TextBox.Instance.textComponent.color = Color.black;
		PanelManager.Instance.CreateNewText ("Como assim, reserva!?");
		
		while (TextBox.Instance.finished == false) {
			yield return null;
		}
		
		TextBox.Instance.textComponent.color = green;
		ProfSprites.Instance.Pose1 ();
		PanelManager.Instance.CreateNewText (@"O GAMUX não tem sala própria caro bixo desinformado, somos indies 
demais para isso!
Se tivesse prestado atenção em nossa apresentação, certamente saberia disso.
Mas não se preocupe, informaremos novamente - até lá, nossas reuniões são 
sempre noticiadas pelo site: 
http://www.gamux.com.br/
Ou por nossa página no Facebook: Gamux - ou qualquer meio que qualquer
indivíduo suficientemente curioso não consiga descobrir!");
		
		while (TextBox.Instance.finished == false) {
			yield return null;
		}
		
		TextBox.Instance.textComponent.color = Color.black;
		ProfSprites.Instance.Pose2 ();
		PanelManager.Instance.CreateNewText (@"WOW! Incrível, participarei de TODAS as reuniões deste fabuloso grupo!");
		
		while (TextBox.Instance.finished == false) {
			yield return null;
		}

		yield return new WaitForSeconds (0.75f);

		FadeOut.Instance.BeginFadeOut ();
		while (FadeOut.Instance.finishedFade == false)
			yield return null;

		yield return new WaitForSeconds (5f);

		Application.LoadLevel("menu");
	}
}
