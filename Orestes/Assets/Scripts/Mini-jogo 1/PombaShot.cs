﻿using UnityEngine;
using System.Collections;

public class PombaShot : MonoBehaviour
{

    public PombaMove pombaMove;
    public GameObject coco;
    public Transform cocoPosition;

    public bool isShooting = false;
    bool shooted = false;
	
    float shotRate;
    float shotCooldown;

    float oscilation = 0f;

    int down = -1;

    void Start()
    {
        shotCooldown = Random.Range(.4f, 1.6f);
        shotRate = shotCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        shotRate -= Time.deltaTime;

        if (shotRate <= 0) {
            isShooting = true;
        }

        if (isShooting) {
            Shoot();
        }
    }

    void Shoot()
    {
        // em que 2f eh a velocidade com que ela oscila
        oscilation += Time.deltaTime * 4f;

        if (oscilation >= Mathf.PI / 2 && !shooted) {
            // Joga o coco de uma vez
            Instantiate(coco, cocoPosition.position, Quaternion.Euler(0, 0, 0));
            shooted = true;

            // down is the new up! para que ela possa subir o que desceu
            down *= -1;
            
			AudioSource a1 = GameObject.Find("PoopSound1").GetComponent<AudioSource>();
			AudioSource a2 = GameObject.Find("PoopSound2").GetComponent<AudioSource>();
            a1.volume = 0.15f;
            a2.volume = 0.15f;
			
			if(!a1.isPlaying)
				a1.Play();
			else if(!a2.isPlaying)
				a2.Play ();
        }

        // em que o fator que multiplica o y eh a magnitude do arco
		rigidbody2D.transform.Translate(new Vector2(pombaMove.speed * Time.deltaTime, down * Mathf.Sin(oscilation) *  Screen.height * 0.0002f));

        if (oscilation >= Mathf.PI) {
            // Reinicia o cooldown
            shotRate = shotCooldown;

            isShooting = false;
            shooted = false;
            oscilation = 0;

            // down is down once again... para a proxima chamada
            down *= -1;
        }
        

    }
}
