using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VanMovement : MonoBehaviour
{
    public float speed;

    bool goingLeft;

    List<Spot> spots = new List<Spot>();

    // Use this for initialization
    void Start()
    {
        goingLeft = true;

        GetComponentsInChildren<Spot>(spots);

        Delay();
    }
	
    // Update is called once per frame
    void Update()
    {
        var speed = this.speed * Time.deltaTime;
        if (goingLeft)
            speed = -speed;
        transform.Translate(speed, 0, 0, Space.World);

        if ((goingLeft && transform.position.x < -15) ||
            ((!goingLeft) && transform.position.x > 15)) {
            var scale = transform.localScale;
            scale.x = -scale.x;
            transform.localScale = scale;

            var rotation = transform.rotation;
            rotation.z = -rotation.z;
            transform.rotation = rotation;

            goingLeft = !goingLeft;

            Delay();
        }
    }

    void Delay() {
        enabled = false;
        foreach (var spot in spots)
            spot.isAvailable = false;
        StartCoroutine(Reactivate());
    }

    IEnumerator Reactivate()
    {
        yield return new WaitForSeconds(Random.Range(2f, 10f));
        enabled = true;
        foreach (var spot in spots)
            spot.isAvailable = true;
    }
}
