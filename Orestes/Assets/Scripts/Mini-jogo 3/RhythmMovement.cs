using UnityEngine;
using System.Collections;

public class RhythmMovement : MonoBehaviour
{
    private static RhythmMovement instance;

    public static RhythmMovement Instance {
        get { return instance; }
    }

    void Awake()
    {
        instance = this;
    }

    void OnDestroy()
    {
        instance = null;
    }

    // Use this for initialization
    void Start()
    {
        RhythmBar.Instance.OnHit += OnHit;
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }

    void OnHit()
    {

    }
}
