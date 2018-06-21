using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vihollistenLiikuminen : MonoBehaviour {

    public float kiihtyvyys;
    public float maxNopeus;
    GameObject pelaaja;
    Rigidbody rb;
    NakeekoPelaajan npScripti;
    VihollisenSeuraus vsScripti;
    LyoPelaajaa lpScripti;
    Vector3 seurausSuunta;
    Animator animaatiot;

	void Start () {
        rb = GetComponent<Rigidbody>();
        kiihtyvyys *= rb.mass;
        pelaaja = GameObject.FindGameObjectWithTag("Player");
        npScripti = GetComponent<NakeekoPelaajan>();
        vsScripti = GetComponent<VihollisenSeuraus>();
        lpScripti = GetComponent<LyoPelaajaa>();
        animaatiot = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        bool nahdaankoPelaaja = npScripti.nahdaankoPelaaja;
        bool pitaakoSeurata = vsScripti.pitaakoSeurata;
        bool ollaankoLyontiEtaisyydella = lpScripti.ollaankoLyontiEtaisyydella;
        animaatiot.SetBool("Juoksussa", false);

        if (nahdaankoPelaaja)
        {
            seurausSuunta = (pelaaja.transform.position - transform.position).normalized;
            seurausSuunta.y = 0;
        }
        if (pitaakoSeurata && !ollaankoLyontiEtaisyydella)
        {
            transform.LookAt(pelaaja.transform);
            rb.AddForce(seurausSuunta.normalized * kiihtyvyys);
            animaatiot.SetBool("Juoksussa", true);
        }
        if (rb.velocity.magnitude > maxNopeus)
        {
            rb.velocity = rb.velocity.normalized * maxNopeus;
        }
	}
}
