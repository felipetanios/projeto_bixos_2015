using UnityEngine;
using System.Collections;

public class RhythmBar : MonoBehaviour
{
    public Texture indicatorTexture;
    public Texture targetTexture;

    private GameObject indicator;

    private float velocity;
    private float position;

    private float start;
    private float width;

    private float leftTarget;
    private float rightTarget;

    private int  requiredHits;
    private float hits;

    public void SpeedUp(int percent)
    {
        velocity *= 1 + percent;
    }

    public int RequiredHits
    {
        get { return requiredHits; }
        set { requiredHits = value; }
    }

    public void ResetHits()
    {
        hits = 0;
    }

    // Use this for initialization
    void Awake()
    {
        useGUILayout = false;

        guiTexture.pixelInset = new Rect {
            x = Screen.width * (6 / 20f),
            y = Screen.height * (1 / 20f),
            width = Screen.width * (8 / 20f),
            height = Screen.width * (3 / 20f)
        };

        indicator = new GameObject();
        indicator.AddComponent<GUITexture>();

        indicator.transform.parent = gameObject.transform;
        indicator.transform.position = new Vector3(0, 0, 1);

        indicator.guiTexture.texture = indicatorTexture;
        indicator.guiTexture.color = Color.black; // FIXME
        indicator.guiTexture.pixelInset = new Rect {
            x = Screen.width * (19 / 60f),
            y = Screen.height * (1 / 40f),
            width = Screen.width * (1 / 60f),
            height = Screen.width * (7 / 40f)
        };

        start = indicator.guiTexture.pixelInset.x;
        width = guiTexture.pixelInset.width - (3*indicator.guiTexture.pixelInset.width);

        var objectLeftTarget = new GameObject();
        objectLeftTarget.AddComponent<GUITexture>();
        objectLeftTarget.transform.parent = gameObject.transform;
        objectLeftTarget.transform.position = new Vector3(0, 0, 0.5f);

        objectLeftTarget.guiTexture.texture = targetTexture;
        objectLeftTarget.guiTexture.color = Color.blue; // FIXME
        objectLeftTarget.guiTexture.pixelInset = new Rect {
            x = Screen.width * (20 / 60f),
            y = Screen.height * (1 / 40f),
            width = Screen.width * (1 / 60f),
            height = Screen.width * (7 / 40f)
        };

        leftTarget = Screen.width * (41 / 120f);

        var objectRightTarget = new GameObject();
        objectRightTarget.AddComponent<GUITexture>();
        objectRightTarget.transform.parent = gameObject.transform;
        objectRightTarget.transform.position = new Vector3(0, 0, 0.5f);

        objectRightTarget.guiTexture.texture = targetTexture;
        objectRightTarget.guiTexture.color = Color.blue; // FIXME
        objectRightTarget.guiTexture.pixelInset = new Rect {
            x = Screen.width * (39 / 60f),
            y = Screen.height * (1 / 40f),
            width = Screen.width * (1 / 60f),
            height = Screen.width * (7 / 40f)
        };

        rightTarget = Screen.width * (79 / 120f);

        velocity = 0.75f;
        requiredHits = 30; // FIXME
    }
	
    void Update()
    {
        UpdatePosition();
        DetectHit();

        if (hits >= requiredHits) {
            enabled = false;
            // TODO mudar para o modo normal
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
            var spacing = inset.width;
            var distanceLeft = Mathf.Abs((inset.x + (inset.width / 2)) - leftTarget);
            var distanceRight = Mathf.Abs((inset.x + (inset.width / 2)) - rightTarget);
            var distance = Mathf.Min(distanceLeft, distanceRight);

            float tmp = 0;
            if (distance <= (1/3f)*spacing)
                tmp = 1.2f;
            else if (distance <= (2/3f)*spacing)
                tmp = 1.0f;
            else if (distance <= (3/3f)*spacing)
                tmp = 0.5f;

            hits += tmp;
        }
    }
}
