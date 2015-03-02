using UnityEngine;
using System.Collections;

public class Cena4bManager : MonoBehaviour
{
	public Color blue;
	public Color green;

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

        ret = TextBox.Instance.Type(@"(Ué... Tudo indica que aqui é o lugar certo, mas…
por que a porta está fechada!? Isso não faz nenhum sentido!)", blue);
        while (ret.MoveNext())
            yield return ret.Current;

        ret = TextBox.Instance.Type("(Eu devo realmente não saber de nada!\n" +
	"Afinal de contas, eu devo ser apenas.\t.\t. um bixão.\t.\t.)", blue);
        while (ret.MoveNext())
            yield return ret.Current;

        yield return new WaitForSeconds(.2f);

        ret = ImageManager.Instance.FadeTo(1f, .2f);
        while (ret.MoveNext())
            yield return ret.Current;

        ret = TextBox.Instance.Type("(Ei! Espera! Um veterano esperto!)", blue);
        while (ret.MoveNext())
            yield return ret.Current;

        ret = TextBox.Instance.Type("Veterano!");
        while (ret.MoveNext())
            yield return ret.Current;

        yield return new WaitForSeconds(.2f);

        ret = TextBox.Instance.Type(@"Sim?", green);
        while (ret.MoveNext())
            yield return ret.Current;

        yield return new WaitForSeconds(.2f);

        ret = TextBox.Instance.Type("Eu preciso muito entrar no IC, mas a porta está fechada!");
        while (ret.MoveNext())
            yield return ret.Current;

        yield return new WaitForSeconds(.2f);

		ret = TextBox.Instance.Type(@"É evidente... É bem comum que o IC tenha alguma de suas entradas 
fechadas de vez em quando, como essa, ao que tudo aponta... 
Tente ir pelos fundos!", green);
        while (ret.MoveNext())
            yield return ret.Current;

        ret = TextBox.Instance.Type(@"Uau! Então tudo faz sentido!
Eu não devo ser apenas um bixão, afinal de contas!");
        while (ret.MoveNext())
            yield return ret.Current;

        yield return new WaitForSeconds(.2f);

		ret = TextBox.Instance.Type("Não...\nVocê ainda é um bixão.", green);
        while (ret.MoveNext())
            yield return ret.Current;

        ret = TextBox.Instance.Type("\t\t. \t\t. \t\t. \t\t\nOK.");
        while (ret.MoveNext())
            yield return ret.Current;

        yield return new WaitForSeconds(.5f);

		FadeOut.Instance.BeginFadeOut ();
        while (FadeOut.Instance.finishedFade == false)
            yield return null;

        //  TODO: link to cena5
        //Application.LoadLevel("cena5");
    }
}