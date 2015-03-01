using UnityEngine;
using System.Collections;

public class Bixo3 : MonoBehaviour {
	
	private static Bixo3 instance;
	public static Bixo3 Instance {
		get { return instance; }
	}
	
	public Animator animator;
	
	void Awake()
	{
		instance = this;
	}
	
	void OnDestroy()
	{
		instance = null;
	}
	
	public void Careca()
	{
		animator.SetBool ("Careca", true);
	}	
	
}