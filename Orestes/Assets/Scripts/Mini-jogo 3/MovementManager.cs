using UnityEngine;
using System.Collections;

public class MovementManager : MonoBehaviour
{

    public enum Mode
    {
        Run,
        Rhythm
    }

    private Mode mode;

    private static MovementManager instance;

    public static MovementManager Instance {
        get { return instance; }
    }

    public void ChangeMode(Mode mode)
    {
        this.mode = mode;
        switch (mode) {
            case Mode.Run:
                RunMovement.Instance.enabled = true;
                RhythmMovement.Instance.enabled = false;
                break;
            case Mode.Rhythm:
                RhythmMovement.Instance.enabled = true;
                RunMovement.Instance.enabled = false;
                break;
        }
    }

    // Use this for initialization
    void Awake()
    {
        instance = this;
    }

    void OnDestroy()
    {
        instance = null;
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }
}
