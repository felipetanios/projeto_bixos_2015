using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour
{
	private GameObject indicator;

	public delegate void OnComplete();

	public OnComplete Complete {
	    get; set;
	}

	public float progresso {
	    get;
	    private set;
	}

	private readonly int TEMPO_TOTAL = 2 * 60; //segundos

	private int flinchCounter = 0;
	private int blinkCounter = 0;

	private float start;
	private float width;

	// Use this for initialization
    void Awake()
	{
	    indicator = transform.GetChild(0).gameObject;

        useGUILayout = false;

	    guiTexture.pixelInset = new Rect {
	        x = Screen.width * (1 / 20f),
	        y = Screen.height * (1 / 20f),
	        width = Screen.width * (18 / 20f),
	        height = Screen.width * (1 / 40f)
	    };

	    indicator.transform.position = new Vector3(0, 0, 1);

	    indicator.guiTexture.pixelInset = new Rect {
	        x = Screen.width * (1 / 20f),
	        y = Screen.height * (1 / 20f) - 25,
	        width = 100,
	        height = 100
	    };

	    start = guiTexture.pixelInset.x;
	    width = guiTexture.pixelInset.width - indicator.guiTexture.pixelInset.width;
	}

	public void Hit(int power)
	{
	    if (flinchCounter == 0 && blinkCounter == 0) {
	        flinchCounter = power * 25;
	        blinkCounter = power * 20;
	    } else {
	        // Já foi atingido, aumentar menos o tempo
	        flinchCounter += power * 12;
	        blinkCounter += power * 10;
	    }
	}

	// FixedUpdate is called once per physics frame
	void FixedUpdate()
	{
	    var inset = indicator.guiTexture.pixelInset;

	    // Dano, retroceder
	    if (flinchCounter > 0) {

	        progresso -= 2 * (Time.fixedDeltaTime / TEMPO_TOTAL);

	        flinchCounter--;
	        if (progresso == 0)
	            flinchCounter = 0;
	    } else {
	        progresso += (Time.fixedDeltaTime / TEMPO_TOTAL);
	    }

	    if (blinkCounter > 0) {
	        if (blinkCounter % 24 < 12)
	            indicator.guiTexture.color = Color.grey;
	        else
	            indicator.guiTexture.color = Color.red;
	        blinkCounter--;
	    }

	    progresso = Mathf.Clamp01(progresso);
	    inset.x = start + (width * progresso);

	    indicator.guiTexture.pixelInset = inset;

	    if (progresso == 1) {
	        // Fim da execução, parar os Updates
	        enabled = false;
	        if (Complete != null)
	            Complete();
	    }
	}
}
