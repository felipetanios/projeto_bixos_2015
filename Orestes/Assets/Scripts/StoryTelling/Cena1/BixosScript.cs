﻿using UnityEngine;
using System.Collections;

public class BixosScript : MonoBehaviour {
	public bool isCorrect = false;

	void OnMouseDown () {
		if (isCorrect)
			Cena1Manager.Instance.correctChoice = true;
		else
			PanelManager.Instance.CreateNewText ("TENTE NOVAMENTE, BIXO BURRO.");
	}
}
