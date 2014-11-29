using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{

    public float spaceGoneInX;
    private bool isOnCollider;
	public float layersSpeed;
	public float defaultSpeed;

    // Use this for initialization
    void Start()
    {
        isOnCollider = false;
        spaceGoneInX = 20.0F;

    }
	
    // Update is called once per frame
    void Update()
    {
        if (isOnCollider) {
            transform.position = new Vector3(transform.position.x + spaceGoneInX, transform.position.y, transform.position.z);
            isOnCollider = false;
        } else {
            transform.Translate((-1) * defaultSpeed * layersSpeed * Time.deltaTime, 0, 0);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        isOnCollider = true;
    }
}
