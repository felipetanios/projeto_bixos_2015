using UnityEngine;
using System.Collections;

public class Cena2Manager : MonoBehaviour
{

    public Sprite outsideSprite;
    public Sprite insideSprite;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Scene());
    }

    private IEnumerator Scene()
    {
        // Delay
        yield return new WaitForEndOfFrame();

        var imageManager = ImageManager.Instance;

        IEnumerator ret;

        imageManager.AlphaTo(0);
        imageManager.SwitchImage(outsideSprite);
        ret = imageManager.FadeTo(1);
        while (ret.MoveNext())
            yield return ret.Current;

        PanelManager.Instance.EnableUI();

        ret = TextBox.Instance.Type(@"Bom... Antes de minha aventura, nada como
uma saborosa refeição nesse ""Restaurante Universitário""!
Mal posso esperar para saborear as delícias que me aguardam!");
        while (ret.MoveNext())
            yield return ret.Current;

        ret = imageManager.FadeTo(0);
        while (ret.MoveNext())
            yield return ret.Current;
        imageManager.SwitchImage(insideSprite);
        ret = imageManager.FadeTo(1);
        while (ret.MoveNext())
            yield return ret.Current;

        ret = TextBox.Instance.Type("Boa tarde, moça! O que tem de almoço hoje?!");
        while (ret.MoveNext())
            yield return ret.Current;

        ret = TextBox.Instance.Type("Cozido misto >:D", Color.red);
        while (ret.MoveNext())
            yield return ret.Current;

    }
}