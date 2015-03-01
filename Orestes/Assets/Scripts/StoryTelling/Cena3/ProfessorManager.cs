using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ParticleSystem))]
public class ProfessorManager : ImageManager
{
    ParticleSystem particles;

    public static new ProfessorManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        image = GetComponent<Image>();
        particles = GetComponent<ParticleSystem>();
    }

    void Destroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public IEnumerator Appears()
    {
        return FadeTo(1f, .1f);
    }

    public IEnumerator Poof()
    {
        particles.Play();
        yield return new WaitForSeconds(.75f);
        var color = image.color;
        color.a = 0;
        image.color = color;
        yield return new WaitForSeconds(.75f);
    }
}