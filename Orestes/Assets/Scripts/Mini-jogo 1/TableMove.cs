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
                var k = Mesa.transform.position.y - child.transform.position.y;
                child.Translate(lugar * 0.00014f * k * k);
                child.transform.localScale += new Vector3(0.025f, 0.0125f, 0);
            }
        }
    }

    void CriaMesa()
    {
        cloneMesa = Instantiate(Mesa, transform.position, transform.rotation) as GameObject;
		
        lugar = new Vector2(transform.position.x * 0.8f, transform.position.y * (-1));

        if (cloneMesa)
            cloneMesa.transform.parent = this.transform;
		
        Destroy(cloneMesa, 12f);
    }
}