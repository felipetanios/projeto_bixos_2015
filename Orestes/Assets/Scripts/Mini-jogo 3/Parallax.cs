using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{
    public float scalingFactor;
    public float jumpSize;
	
    // Update is called once per frame
    void Update()
    {
        var cameraScrolling = CameraScrolling.Instance;
        transform.Translate(cameraScrolling.defaultSpeed * scalingFactor, 0, 0, Space.Self);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("End")) {
            var translateX = jumpSize * (transform.collider2D as BoxCollider2D).size.x;
            translateX *= transform.lossyScale.x;
            transform.Translate(translateX, 0, 0, Space.Self);
        }

    }
}
