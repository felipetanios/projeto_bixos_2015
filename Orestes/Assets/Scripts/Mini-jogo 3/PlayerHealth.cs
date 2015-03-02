using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Enemy") {
			PlayerSprites.Instance.IsJumping(false);
			PlayerSprites.Instance.IsFalling(false);
			PlayerSprites.Instance.DoubleJump(false);

			// Change it to rhythm mode
			MovementManager.Instance.ChangeMode(MovementManager.Mode.Rhythm);
			
		}
	}
}
