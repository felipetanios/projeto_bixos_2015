using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class ButtonsGamux : MonoBehaviour
{
	public Button buttonPrefab;
	
	public static ButtonsGamux Instance { get; private set; }
	
	public bool HasChosen { get; private set; }
	
	void Awake()
	{
		if (Instance == null)
			Instance = this;
	}
	
	void Destroy()
	{
		if (Instance == this)
			Instance = null;
	}
	
	public void DeleteOptions()
	{
		var children = new List<Transform>(transform.Cast<Transform>());
		foreach (var child in children) {
			Destroy(child.gameObject);
		}
	}
	
	public void AddOptions(params string[] options)
	{
		var first = true;

		foreach (var option in options) {
			var newButton = (Button) Instantiate(buttonPrefab);
			newButton.transform.SetParent(transform, false);
			newButton.GetComponentInChildren<Text>().text = option;
			if (option.Length > 35)
				newButton.GetComponentInChildren<Text>().fontSize = 64;
			if (first == true) {
				newButton.onClick.AddListener(() => { HasChosen = true; });
				first = false;
			}
			else
				newButton.onClick.AddListener(() => { 
					PanelManager.Instance.CreateNewText ("TENTE NOVAMENTE, BIXO BURRO."); });
		}
		
		HasChosen = false;
	}
}