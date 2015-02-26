using UnityEngine;
using System.Collections;

public class MovementManager : MonoBehaviour
{
    public enum Mode
    {
        Run,
        Rhythm,
		End
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
		if (other.tag == "EndGame") {
			ChangeMode(Mode.End);
		}
	}

    public void ChangeMode(Mode mode)
    {
		this.mode = mode;

        switch (mode) {
            case Mode.Run:
                RunMovement.Instance.enabled = true;

				// Never forget the sprites
				PlayerSprites.Instance.IsRunning(true);

                RhythmMovement.Instance.enabled = false;
				RhythmBar.Instance.gameObject.SetActive(false);

                break;

            case Mode.Rhythm:
                RhythmMovement.Instance.enabled = true;

				// Never forget the sprites
				PlayerSprites.Instance.IsRunning(false);

				RunMovement.Instance.enabled = false;

				RhythmBar.Instance.gameObject.SetActive(true);
				// Set your stuff, Im waking you up!
				RhythmBar.Instance.WokeUp ();

				break;
			case Mode.End:
				RhythmMovement.Instance.enabled = false;
				
				// Never forget the sprites
				PlayerSprites.Instance.IsRunning(false);
				PlayerSprites.Instance.End();
				
				RunMovement.Instance.enabled = false;
				RhythmMovement.Instance.enabled = true;

				RhythmBar.Instance.gameObject.SetActive(false);
				
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
