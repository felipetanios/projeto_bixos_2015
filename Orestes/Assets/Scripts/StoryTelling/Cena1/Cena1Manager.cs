﻿using UnityEngine;
using System.Collections;

public class Cena1Manager : MonoBehaviour {

	public GameObject[] bixos;
	[HideInInspector] public bool canProceed = false;
	[HideInInspector] public bool goAway = false;
	
	public static Cena1Manager Instance { get; private set; }
	
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
		StartCoroutine ("Scene1");
	}
	
	IEnumerator Scene1 () {        

		var imageManager = ImageManager.Instance;
		
		IEnumerator ret;
		
		imageManager.AlphaTo(0);
		ret = imageManager.FadeTo(1);
		while (ret.MoveNext())
			yield return ret.Current;
		
		PanelManager.Instance.EnableUI();
		
		PanelManager.Instance.CreateNewText ("Bem-vindo ao maravilhoso mundo do GAMUX, caro bixo ingênuo!");

		while (TextBox.Instance.finished == false) {
			yield return null;
		}

		ProfSprites.Instance.Pose1 ();
		PanelManager.Instance.CreateNewInput ("Você parece deveras inteligente, jovem jogador.\nAntes de prosseguir, pode-me dizer o seu nome? ");

		while (InputString.Instance.finished == false) {
			yield return null;
		}

		ProfSprites.Instance.Pose2 ();
		PanelManager.Instance.CreateNewText ("Você tem certeza que quer se chamar \"BIXO BURRO\"?\n...");
		
		while (TextBox.Instance.finished == false) {
			yield return null;
		}

		ButtonsManager.Instance.AddOptions(
			"Com certeza.",
			"Não!");
		
		while (!ButtonsManager.Instance.HasChosen)
			yield return new WaitForFixedUpdate();

		yield return new WaitForSeconds(.2f);
		
		ButtonsManager.Instance.DeleteOptions();
		
		ProfSprites.Instance.Pose1 ();
		PanelManager.Instance.CreateNewText ("Neste caso: bem-vindo, BIXO BURRO!");

		while (TextBox.Instance.finished == false) {
			yield return null;
		}

		ProfSprites.Instance.ProfObject ().SetActive (false);
		foreach (GameObject bixo in bixos) {
			Instantiate(bixo, bixo.transform.position, bixo.transform.rotation);
		}

		PanelManager.Instance.CreateNewText ("Escolha o avatar em que você mais se identifica!");
		
		while (canProceed == false) {
			yield return null;
		}
		
		canProceed = false;

		PanelManager.Instance.CreateNewText ("Excelente escolha, BIXO BURRO, exceto que...");

		yield return new WaitForSeconds(4);
		Maquina0.Instance.Raspe ();
		yield return new WaitForSeconds(0.7f);
		Bixo3.Instance.Careca ();
		
		yield return new WaitForSeconds(2);
	
		goAway = true;
		ProfSprites.Instance.ProfObject ().SetActive (true);

		PanelManager.Instance.CreateNewText ("Pois bem, você parece-me ser um bixo bastante perspicaz,\no que você imagina que o GAMUX é, a partir\nda ilustríssima apresentação que você acabou de presenciar?");

		while (TextBox.Instance.finished == false) {
			yield return null;
		}

		ButtonsGamux.Instance.AddOptions(
			"Um núcleo de produção de jogos indie",
			"Uma padaria",
			"Uma confecção camisetas de animais fofos",
			"Uma montadora de veículos",
			"Time de e-sport");

		while (!ButtonsGamux.Instance.HasChosen)
			yield return new WaitForFixedUpdate();
		
		yield return new WaitForSeconds(.2f);
		
		ButtonsGamux.Instance.DeleteOptions();
	}
}