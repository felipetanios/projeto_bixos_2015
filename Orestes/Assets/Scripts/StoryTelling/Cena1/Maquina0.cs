using UnityEngine;
using System.Collections;

public class Maquina0 : MonoBehaviour {

	private static Maquina0 instance;
	public static Maquina0 Instance {
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
	
	public void Raspe()
	{
		animator.SetTrigger ("Raspe");
	}	

}
