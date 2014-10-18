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
		InvokeRepeating("CriaMesa", 2, 2);
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		foreach (Transform child in transform){
			if(child){
				child.Translate(lugar * (0.01f));
				child.transform.localScale += new Vector3(0.004f, 0.002f, 0);
			}
		}
	}
	
	void CriaMesa()
	{
		cloneMesa = Instantiate(Mesa, transform.position, transform.rotation) as GameObject;
		
		lugar = new Vector2(transform.position.x * 1.5f, transform.position.y * (-1));

		if(cloneMesa)
			cloneMesa.transform.parent = this.transform;
		
		Destroy(cloneMesa, 4f);
	}
}