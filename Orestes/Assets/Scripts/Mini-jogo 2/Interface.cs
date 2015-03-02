using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class Interface : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject pausaPanel;
    public GameObject scorePanel;

    public GameObject pausaButton;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0;
        tutorialPanel.SetActive(true);
    }

    public void Pausa()
    {
        Time.timeScale = 0;
        pausaPanel.SetActive(true);
        pausaButton.SetActive(false);
    }

    public void Mutar()
    {
        var listener = Camera.main.GetComponent<AudioListener>();
        listener.enabled = !listener.enabled;
    }

    public void Juego()
    {
        Time.timeScale = 1;

        tutorialPanel.SetActive(false);
        pausaPanel.SetActive(false);
        pausaButton.SetActive(true);
    }

    public void Score(string score)
    {
        scorePanel.SetActive(true);
        scorePanel.GetComponentInChildren<Text>().text = score;
    }

    public void Continuar()
    {
        Application.LoadLevel("cena3b");
    }


    public void Sair()
    {
        // ☹
        Application.Quit();
    }
}
