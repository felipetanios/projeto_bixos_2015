using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    public GameObject creditosPanel;

    public void Iniciar()
    {
        Application.LoadLevel("cena1");
    }

    public void MostraCreditos(bool mostra)
    {
        creditosPanel.SetActive(mostra);
    }

}
