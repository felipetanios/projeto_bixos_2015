using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Cena3Manager : MonoBehaviour
{

    public AudioClip poof;
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

        IEnumerator ret;

        PanelManager.Instance.EnableUI();

        ret = TextBox.Instance.Type(@"(Bolas, acho que estou perdido!
Melhor perguntar para algum professor, o que poderia dar errado?)", blue);
        while (ret.MoveNext())
            yield return ret.Current;

        yield return new WaitForSeconds(.2f);

        ret = ProfessorManager.Instance.Appears();
        while (ret.MoveNext())
            yield return ret.Current;

        ret = TextBox.Instance.Type(@"(Olha, um professor!
Vou perguntar para ele)", blue);
        while (ret.MoveNext())
            yield return ret.Current;

        ret = TextBox.Instance.Type(@"Profes...", false, false);
        while (ret.MoveNext())
            yield return ret.Current;

        ret = ProfessorManager.Instance.Poof();
        while (ret.MoveNext())
            yield return ret.Current;

        ret = TextBox.Instance.Type(@"(Pra onde ele foi!?
Preciso encontrar algum professor!)", blue);
        while (ret.MoveNext())
            yield return ret.Current;

        yield return new WaitForSeconds(.2f);

        Application.LoadLevel("game2");
    }
}