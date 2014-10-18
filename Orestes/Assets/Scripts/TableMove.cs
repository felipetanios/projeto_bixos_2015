using UnityEngine;
using System.Collections;

public class TableMove : MonoBehaviour {

	public GameObject Mesa;
	public Vector2 lugar;
	private GameObject cloneMesa;
	// Use this for initialization
	void Start (){
		InvokeRepeating ("CriaMesa", 2, 2);
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Transform child in transform)
			child.Translate (lugar * (0.01f));
	}

	void CriaMesa(){
		cloneMesa = Instantiate (Mesa, transform.position, transform.rotation) as GameObject;
		
		lugar = new Vector2 (transform.position.x, transform.position.y *(-1));

		cloneMesa.transform.parent = this.transform;
		
		Destroy (cloneMesa, 4f);
	}
}