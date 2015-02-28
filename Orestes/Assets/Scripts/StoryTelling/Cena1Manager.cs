using UnityEngine;
using System.Collections;

public class Cena1Manager : MonoBehaviour {
	// Use this for initialization
	void Start () {
		StartCoroutine ("Scene1");
	}
	
	IEnumerator Scene1 () {
		PanelManager.Instance.CreateNewText ("Bem-vindo ao maravilhoso mundo do GAMUX, caro bixo ingênuo!");

		while (TextBox.Instance.finished == false) {
			yield return null;
		}

		PanelManager.Instance.CreateNewInput ("Você parece deveras inteligente, caro bixo ingênuo. Antes de prosseguir,\npode-me dizer o seu nome? ");

		while (TextBox.Instance.finished == false) {
			yield return null;
		}
		
	}
}