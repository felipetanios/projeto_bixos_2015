using UnityEngine;
using System.Collections;

public class TableMove : MonoBehaviour
{
	
    public GameObject Mesa;
    public Vector2 lugar;
    private GameObject cloneMesa;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("CriaMesa", 2, 3.4f);
    }
	
    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Transform child in transform) {
            if (child) {
				float k = 0.04f;
				child.transform.Translate(lugar* k);
                child.transform.localScale += new Vector3(0.025f, 0.0125f, 0);
				k+=0.02f;
            }
        }
    }

    void CriaMesa()
    {
        cloneMesa = Instantiate(Mesa, transform.position, transform.rotation) as GameObject;

		if (transform.position.x > 0.0f)
			lugar = new Vector2(1 * transform.position.x*0.9f, -1);
		else
			lugar = new Vector2(-1 * transform.position.x*0.9f, -1);

        if (cloneMesa)
            cloneMesa.transform.parent = this.transform;
		
        Destroy(cloneMesa, 12f);
    }
}