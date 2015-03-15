using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (MovementManager.Instance.mode == MovementManager.Mode.Rhythm) {
			collider2D.enabled = false;
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "End")
            Destroy(gameObject);
    }
}