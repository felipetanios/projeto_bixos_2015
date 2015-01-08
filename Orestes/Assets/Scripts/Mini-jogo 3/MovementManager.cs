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

	void Start ()
	{
		ChangeMode (Mode.Rhythm);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "EndGame")
			Debug.Log ("Reached the end.");
	}

    public void ChangeMode(Mode mode)
    {
		this.mode = mode;

        switch (mode) {
            case Mode.Run:
                RunMovement.Instance.enabled = true;
				PlayerSprites.Instance.IsRunning(true);

                RhythmMovement.Instance.enabled = false;
				RhythmBar.Instance.gameObject.SetActive(false);

                break;

            case Mode.Rhythm:
                RhythmMovement.Instance.enabled = true;
				PlayerSprites.Instance.IsRunning(false);

				RunMovement.Instance.enabled = false;
				RhythmBar.Instance.gameObject.SetActive(true);

				RhythmBar.Instance.WokeUp ();

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
