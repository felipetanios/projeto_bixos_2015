using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Cena4Manager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Scene());
    }

    private IEnumerator Scene()
    {
        // Delay
        yield return new WaitForEndOfFrame();

        IEnumerator ret;

        PanelManager.Instance.EnableUI();

        ret = TextBox.Instance.Type(@"(Segundo meu mapa, o IC fica por aqui,
só preciso subir essa pequena ladeira...)", Color.blue);
        while (ret.MoveNext())
            yield return ret.Current;

        ret = TextBox.Instance.Type(@"Não pode ser tão difícil!", false, false);
        // Need to pan alongside text, so start in another coroutine
        // PanTo will end after this one, so we can do this
        StartCoroutine(ret);

        ret = BackgroundManager.Instance.PanTo(-2080, 10f);
        while (ret.MoveNext())
            yield return ret.Current;

        yield return new WaitForSeconds(1f);

        ret = BackgroundManager.Instance.FadeTo(0);
        while (ret.MoveNext())
            yield return ret.Current;

        Application.LoadLevel("game3");
    }
}