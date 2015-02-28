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

        ret = TextBox.Instance.Type("Escolha sua refeição", Color.yellow, false);
        while (ret.MoveNext())
            yield return ret.Current;

        ButtonsManager.Instance.AddOptions(
            "Filé de Salmão",
            "Batata frita",
            "Lasanha",
            "Macarrão",
            "Hambúrguer de picanha",
            "Cozido Misto");

        while (!ButtonsManager.Instance.HasChosen)
            yield return new WaitForFixedUpdate();

        yield return new WaitForSeconds(.2f);

        ButtonsManager.Instance.DeleteOptions();

        ret = TextBox.Instance.Type("(Blergh, cozido misto...)", Color.blue, false);
        while (ret.MoveNext())
            yield return ret.Current;

        ret = TextBox.Instance.Type("Vocẽ quer MUITO, ou POUCO?", Color.yellow, false);
        while (ret.MoveNext())
            yield return ret.Current;

        ButtonsManager.Instance.AddOptions(
            "MUITO",
            "POUCO");

        while (!ButtonsManager.Instance.HasChosen)
            yield return new WaitForFixedUpdate();

        yield return new WaitForSeconds(.2f);

        ButtonsManager.Instance.DeleteOptions();

    }
}