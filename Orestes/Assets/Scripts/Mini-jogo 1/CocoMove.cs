using UnityEngine;
using System.Collections;

public class CocoMove : MonoBehaviour
{

    public float speed = 8f;
    bool grounded = false;

    public Animator splash;

    public GameObject progressObject;
    ProgressBar progressScript;

    void Start()
    {
        progressObject = GameObject.FindGameObjectWithTag("Progress");

        progressScript = progressObject.GetComponent<ProgressBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!grounded)
            rigidbody2D.transform.Translate(new Vector2(0, -speed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground") {
            grounded = true;
            StartCoroutine("Die");
        } else if (other.tag == "Player") {
            Destroy(gameObject);

            // Faz o dano no jogador 
            if (progressScript.progresso <= .5f)
                progressScript.Hit(3);
            else if (progressScript.progresso <= .7f)
                progressScript.Hit(5);
            else
                progressScript.Hit(8);
        }
    }

    IEnumerator Die()
    {
        splash.SetTrigger("Dead");
        Destroy(rigidbody2D);
        collider2D.enabled = false;

        yield return new WaitForSeconds(1.8f);
        Destroy(gameObject);
    }
}