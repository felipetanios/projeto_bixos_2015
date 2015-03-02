using UnityEngine;
using System.Collections;

public class RhythmBar : MonoBehaviour
{
    public Texture indicatorTexture;
    public Texture targetTexture;

    private GameObject indicator;

	public float maxVelocity = 3;
    private float velocity;
    private float position;

    private float start;
    private float width;

    private float leftTarget;
    private float rightTarget;

    private int requiredHits;
    private float hits;
	private int timesTried;

    private static RhythmBar instance;

    public delegate void HitCallback();

	public bool justWoke;

    public void SpeedUp(float percent)
    {
		if (velocity < maxVelocity)
	        velocity *= 1 + percent;
    }

    public static RhythmBar Instance {
        get { return instance; }
    }

    public int RequiredHits {
        get { return requiredHits; }
        set { requiredHits = value; }
    }

    public HitCallback OnHit {
        get;
        set;
    }

    public void ResetHits()
    {
        hits = 0;
    }

    // Use this for initialization
    void Awake()
    {
        instance = this;

        useGUILayout = false;

        guiTexture.pixelInset = new Rect {
            x = Screen.width * (6 / 20f),
            y = Screen.height * (1.5f / 100f),
            width = Screen.width * (8 / 20f),
            height = Screen.width * (1.25f / 20f)
        };

        indicator = new GameObject();
        indicator.AddComponent<GUITexture>();

        indicator.transform.parent = gameObject.transform;
        indicator.transform.position = new Vector3(0, 0, 1);

        indicator.guiTexture.texture = indicatorTexture;
        //indicator.guiTexture.color = Color.black; // FIXME
        indicator.guiTexture.pixelInset = new Rect {
            x = Screen.width * (5.27f / 20f),
            y = Screen.height * (1 / 40f),
            width = Screen.width * (2.1f / 20f),
            height = Screen.width * (4.45f / 40f)
        };

        start = indicator.guiTexture.pixelInset.x;
        width = guiTexture.pixelInset.width - (0.3f * indicator.guiTexture.pixelInset.width);

        var objectLeftTarget = new GameObject();
        objectLeftTarget.AddComponent<GUITexture>();
        objectLeftTarget.transform.parent = gameObject.transform;
        objectLeftTarget.transform.position = new Vector3(0, 0, 0.5f);

        objectLeftTarget.guiTexture.texture = targetTexture;
		var alpha0 = objectLeftTarget.guiTexture.color;
		alpha0.a = 0;
		objectLeftTarget.guiTexture.color = alpha0;
        objectLeftTarget.guiTexture.pixelInset = new Rect {
            x = Screen.width * (6.21f / 20f),
            y = Screen.height * (1.3f / 40f),
            width = Screen.width * (1f / 100f),
            height = Screen.width * (2 / 40f)
        };

		leftTarget = objectLeftTarget.guiTexture.pixelInset.x;

        var objectRightTarget = new GameObject();
        objectRightTarget.AddComponent<GUITexture>();
        objectRightTarget.transform.parent = gameObject.transform;
        objectRightTarget.transform.position = new Vector3(0, 0, 0.5f);

        objectRightTarget.guiTexture.texture = targetTexture;
		alpha0 = objectRightTarget.guiTexture.color;
		alpha0.a = 0;
		objectRightTarget.guiTexture.color = alpha0;
        objectRightTarget.guiTexture.pixelInset = new Rect {
			x = Screen.width * (13.45f / 20f),
			y = Screen.height * (1.3f / 40f),
			width = Screen.width * (1f / 100f),
			height = Screen.width * (2 / 40f)
        };

		rightTarget = objectRightTarget.guiTexture.pixelInset.x;

        velocity = 0.75f;
		timesTried = 1;

		WokeUp ();
    }

    void OnDestroy()
    {
        instance = null;
    }

	public void WokeUp ()
	{
		requiredHits = 3 * timesTried;
	}

    void Update()
    {
        UpdatePosition();
        DetectHit();
				
		if (hits >= requiredHits) {
			hits = 0;
			SpeedUp(0.2f);

			// Change it back to run mode
			MovementManager.Instance.ChangeMode(MovementManager.Mode.Run);
        }
    }

    void UpdatePosition()
    {
        var inset = indicator.guiTexture.pixelInset;

        position += velocity * Time.deltaTime;

        position = Mathf.Clamp01(position);
        inset.x = start + (width * position);

        indicator.guiTexture.pixelInset = inset;

		if (position == 0 || position == 1)
            velocity = -velocity;
    }

    void DetectHit()
    {
        if (Input.GetButtonDown("Jump")) {
            var inset = indicator.guiTexture.pixelInset;
            float spacing = inset.width;
            var distanceLeft = Mathf.Abs((inset.x + (spacing/2)) - leftTarget);
			var distanceRight = Mathf.Abs(rightTarget - (inset.x + (spacing/2)));
            var distance = Mathf.Min(distanceLeft, distanceRight);

            float incr = 0;

			if (distance <= Screen.width * (1f / 100f)) {
				incr = 1;
				GameObject.Find("ProgressHitSound").GetComponent<AudioSource>().Play();
				
			}
            else {
                return;
			}

            hits += incr;

            if (OnHit != null)
                OnHit();
        }
    }
}
