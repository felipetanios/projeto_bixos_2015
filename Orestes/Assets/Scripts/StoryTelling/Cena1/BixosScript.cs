using UnityEngine;
using System.Collections;

public class BixosScript : MonoBehaviour {
	public bool isCorrect = false;

	void OnMouseDown () {
		if (isCorrect)
			Cena1Manager.Instance.canProceed = true;
		else
			PanelManager.Instance.CreateNewText ("TENTE NOVAMENTE, BIXO BURRO.");
	}

	void Update () {
		if (Cena1Manager.Instance.goAway == true && !isCorrect) {
			Destroy(gameObject);
		}
	}
}
