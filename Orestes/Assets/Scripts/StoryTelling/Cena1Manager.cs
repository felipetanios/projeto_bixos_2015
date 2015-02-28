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

		PanelManager.Instance.CreateNewInput ("Você parece deveras inteligente, caro bixo ingênuo.\nAntes de prosseguir, pode-me dizer o seu nome? ");

		while (InputString.Instance.finished == false) {
			yield return null;
		}
		
		PanelManager.Instance.CreateNewText ("Você tem certeza que quer se chamar BIXO BURRO?\n...");

		while (TextBox.Instance.finished == false) {
			yield return null;
		}

		PanelManager.Instance.CreateNewText ("Bem-vindo novamente, BIXO BURRO!");

		while (TextBox.Instance.finished == false) {
			yield return null;
		}

		PanelManager.Instance.CreateNewText ("Escolha o avatar em que você mais se identifica!");
	}
}