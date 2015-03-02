using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class Jogo1Tutorial : MonoBehaviour
{
    public GameObject tutorialPanel;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0;
        tutorialPanel.SetActive(true);
    }

    public void Juego()
    {
        Time.timeScale = 1;

        tutorialPanel.SetActive(false);
    }
}
