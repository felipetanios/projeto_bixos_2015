using UnityEngine;
using System.Collections;

public class PlayerSprites : MonoBehaviour 
{
	private static PlayerSprites instance;
	public static PlayerSprites Instance {
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

	public void IsRunning (bool state)
	{
		animator.SetBool ("Running", state);
	}

	public void IsJumping (bool state)
	{
		animator.SetBool ("isJumping", state);
	}
	
	public void IsFalling(bool state)
	{
		animator.SetBool ("Falling", state);
	}
}
