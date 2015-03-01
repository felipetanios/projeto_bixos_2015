using UnityEngine;
using System.Collections;

public class Cena1Manager : MonoBehaviour {

	public GameObject[] bixos;
	[HideInInspector] public bool correctChoice = false;
	
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
		PanelManager.Instance.CreateNewText ("Bem-vindo ao maravilhoso mundo do GAMUX, caro bixo ingênuo!");

		while (TextBox.Instance.finished == false) {
			yield return null;
		}

		ProfSprites.Instance.Pose1 ();
		PanelManager.Instance.CreateNewInput ("Você parece deveras inteligente, caro bixo ingênuo.\nAntes de prosseguir, pode-me dizer o seu nome? ");

		while (InputString.Instance.finished == false) {
			yield return null;
		}

		ProfSprites.Instance.Pose2 ();
		PanelManager.Instance.CreateNewText ("Você tem certeza que quer se chamar \"BIXO BURRO\"?\n...");

		while (TextBox.Instance.finished == false) {
			yield return null;
		}

		ProfSprites.Instance.Pose1 ();
		PanelManager.Instance.CreateNewText ("Bem-vindo novamente, BIXO BURRO!");

		while (TextBox.Instance.finished == false) {
			yield return null;
		}

		ProfSprites.Instance.ProfObject ().SetActive (false);
		foreach (GameObject bixo in bixos) {
			Instantiate(bixo, bixo.transform.position, bixo.transform.rotation);
		}

		PanelManager.Instance.CreateNewText ("Escolha o avatar em que você mais se identifica!");

		while (correctChoice == false) {
			yield return null;
		}
	}
}