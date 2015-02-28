using UnityEngine;
using System.Collections;

public class ProfSprites : MonoBehaviour 
{
	private static ProfSprites instance;
	public static ProfSprites Instance {
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
	
	public void Pose1()
	{
		animator.SetTrigger ("Pose1");
	}	

	public void Pose2()
	{
		animator.SetTrigger ("Pose2");
	}
	
	public void Pose3()
	{
		animator.SetTrigger ("Pose3");
	}

	public GameObject ProfObject () {
		return gameObject;
	}
}
