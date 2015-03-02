using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Cena2Manager : MonoBehaviour
{

    public AudioClip plop;
    public Sprite outsideSprite;
    public Sprite[] insideSprites;

	public Color green;
	public Color yellow;
	public Color blue;

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
        imageManager.SwitchImage(insideSprites[0]);
        ret = imageManager.FadeTo(1);
        while (ret.MoveNext())
            yield return ret.Current;

        ret = TextBox.Instance.Type("Boa tarde, moça! O que tem de almoço hoje?!");
        while (ret.MoveNext())
            yield return ret.Current;

        ret = TextBox.Instance.Type("Escolha sua refeição:", yellow, false, false);
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

        ret = imageManager.FadeTo(0, .25f);
        while (ret.MoveNext())
            yield return ret.Current;
        imageManager.SwitchImage(insideSprites[1]);
        ret = imageManager.FadeTo(1, .25f);
        while (ret.MoveNext())
            yield return ret.Current;

        ret = TextBox.Instance.Type("(Blergh, cozido misto...)", blue);
        while (ret.MoveNext())
            yield return ret.Current;

        ret = TextBox.Instance.Type("Você quer MUITO, ou POUCO?", yellow, false, false);
        while (ret.MoveNext())
            yield return ret.Current;

        ButtonsManager.Instance.AddOptions(
            "MUITO",
            "POUCO");

        while (!ButtonsManager.Instance.HasChosen)
            yield return new WaitForFixedUpdate();

        ButtonsManager.Instance.DeleteOptions();
        
        audio.PlayOneShot(plop, .5f);
        yield return new WaitForSeconds(.3f);
        imageManager.SwitchImage(insideSprites[2]);
        audio.PlayOneShot(plop, .5f);
        yield return new WaitForSeconds(.3f);
        imageManager.SwitchImage(insideSprites[3]);

        ret = TextBox.Instance.Type("Boa sorte encontrando um... lugar, mas cuidado com as pombas!", green, false);
        while (ret.MoveNext())
            yield return ret.Current;

        yield return new WaitForSeconds(.5f);

        ret = imageManager.FadeTo(0, 1f);
        while (ret.MoveNext())
            yield return ret.Current;

        // Finally, load level
        Application.LoadLevel("game1");
    }
}