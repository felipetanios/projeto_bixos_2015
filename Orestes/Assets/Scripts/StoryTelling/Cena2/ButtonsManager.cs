using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class ButtonsManager : MonoBehaviour
{
    public Button buttonPrefab;

    public static ButtonsManager Instance { get; private set; }

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
        foreach (var option in options) {
            var newButton = (Button) Instantiate(buttonPrefab);
            newButton.transform.SetParent(transform, false);
            newButton.GetComponentInChildren<Text>().text = option;
            newButton.onClick.AddListener(() => { HasChosen = true; });
        }

        HasChosen = false;
    }
}