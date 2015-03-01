using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Cena3bManager : MonoBehaviour
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

        ret = TextBox.Instance.Type(@"Bixo burro, você não sabe que
é perda de tempo procurar um professor do IA!?", Color.green);
        while (ret.MoveNext())
            yield return ret.Current;

        yield return new WaitForSeconds(.2f);

        ret = TextBox.Instance.Type("Mas, eu queria muito saber onde fica o GAMUX...");
        while (ret.MoveNext())
            yield return ret.Current;

        yield return new WaitForSeconds(.2f);

        ret = TextBox.Instance.Type(@"Bom, eu imagino que fique perto do IC,
um lugar bem longínquo e desconhecido pela maior parte da Unicamp.", Color.green);
        while (ret.MoveNext())
            yield return ret.Current;

        yield return new WaitForSeconds(.2f);

        ret = TextBox.Instance.Type("Mas... mas... aonde!?");
        while (ret.MoveNext())
            yield return ret.Current;

        yield return new WaitForSeconds(.2f);

        ret = TextBox.Instance.Type("Bixo.\t.\t.\t.\t.\t. Você tem um mapa...", Color.green);
        while (ret.MoveNext())
            yield return ret.Current;

        yield return new WaitForSeconds(.5f);

        //ret = imageManager.FadeTo(0, 1f);
        //while (ret.MoveNext())
        //    yield return ret.Current;

        // TODO: link to map level
        //Application.LoadLevel(???);
    }
}