using UnityEngine;
using System.Collections;

public class MovementManager : MonoBehaviour
{
    public enum Mode
    {
        Run,
        Rhythm
    }

    public Mode mode;

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

    // Singletons
    void Awake()
    {
        instance = this;
    }

    void OnDestroy()
    {
        instance = null;
    }
}
