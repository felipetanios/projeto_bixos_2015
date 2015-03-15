using UnityEngine;
using System.Collections;
using System;

public class MovementManager : MonoBehaviour
{
    public enum Mode
    {
        Run,
        Rhythm,
        End
    }

    public Mode mode;

    public AudioSource fast;
    public AudioSource slow;

    private static MovementManager instance;

    public static MovementManager Instance {
        get { return instance; }
    }

    void Start()
    {		
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EndGame") {
            ScoreJogo3.Instance.Show();
        }
    }

    public void ChangeMode(Mode mode)
    {
        this.mode = mode;

        switch (mode) {
            case Mode.Run:
                GameObject.Find("InhaleSound").GetComponent<AudioSource>().enabled = false;
                RunMovement.Instance.enabled = true;

				// Never forget the sprites
                PlayerSprites.Instance.IsRunning(true);

                RhythmMovement.Instance.enabled = false;
                RhythmBar.Instance.gameObject.SetActive(false);
                EndMovement.Instance.enabled = false;
				
                try {
                    slow.enabled = false;
                    fast.enabled = true;
                } catch (Exception) {
                    return;
                }
                break;

            case Mode.Rhythm:
                GameObject.Find("InhaleSound").GetComponent<AudioSource>().enabled = true;
                RhythmMovement.Instance.enabled = true;

				// Never forget the sprites
                PlayerSprites.Instance.IsRunning(false);
                PlayerSprites.Instance.Ops();

                RunMovement.Instance.enabled = false;
                EndMovement.Instance.enabled = false;

                RhythmBar.Instance.gameObject.SetActive(true);
				// Set your stuff, Im waking you up!
                RhythmBar.Instance.WokeUp();

                try {
                    slow.enabled = true;	
                    fast.enabled = false;
                } catch (Exception) {
                    return;
                }

                break;
            case Mode.End:
                RhythmMovement.Instance.enabled = false;
				
				// Never forget the sprites
                PlayerSprites.Instance.IsRunning(true);
                PlayerSprites.Instance.IsJumping(false);
                PlayerSprites.Instance.IsFalling(false);
				//PlayerSprites.Instance.End();
				
                RunMovement.Instance.enabled = false;
                RhythmMovement.Instance.enabled = false;
                RhythmBar.Instance.gameObject.SetActive(false);

                EndMovement.Instance.enabled = true;

                FadeOut.Instance.BeginFadeOut();

                break;
        }
    }

    void Update()
    {
        if (FadeOut.Instance.finishedFade == true) {
            Application.LoadLevel("cena4b");
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
