using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vihollistenLiikuminen : MonoBehaviour {

    public float kiihtyvyys;
    public float maxNopeus;
    GameObject pelaaja;
    Rigidbody rb;
    Vector3 seurausSuunta;
    Animator animaatiot;
    EnStates states;

	void Start () {
        rb = GetComponent<Rigidbody>();
        kiihtyvyys *= rb.mass;
        pelaaja = GameObject.FindGameObjectWithTag("Player");
        animaatiot = GetComponent<Animator>();
        states = GetComponent<EnStates>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        animaatiot.SetBool("Juoksussa", false);

        if (states.seesPlayer)
        {
            seurausSuunta = (pelaaja.transform.position - transform.position).normalized;
            seurausSuunta.y = 0;
        }
        if (states.isFollowing && !states.inHittingRange)
        {
            transform.LookAt(pelaaja.transform);
            rb.AddForce(seurausSuunta.normalized * kiihtyvyys);
            animaatiot.SetBool("Juoksussa", true);
            animaatiot.speed = 0.5f + rb.velocity.magnitude / (2 * maxNopeus); //Korjaa tästä johtuva muiden animaatioiden hidastuminen joskus...
        }
        if (rb.velocity.magnitude > maxNopeus)
        {
            rb.velocity = rb.velocity.normalized * maxNopeus;
        }
	}
}
