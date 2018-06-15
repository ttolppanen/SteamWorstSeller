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

	void Start () {
        rb = GetComponent<Rigidbody>();
        pelaaja = GameObject.FindGameObjectWithTag("Player");
        npScripti = GetComponent<NakeekoPelaajan>();
        vsScripti = GetComponent<VihollisenSeuraus>();
        lpScripti = GetComponent<LyoPelaajaa>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        bool nahdaankoPelaaja = npScripti.nahdaankoPelaaja;
        bool pitaakoSeurata = vsScripti.pitaakoSeurata;
        bool ollaankoLyontiEtaisyydella = lpScripti.ollaankoLyontiEtaisyydella;

        if (nahdaankoPelaaja)
        {
            seurausSuunta = (pelaaja.transform.position - transform.position).normalized;
            seurausSuunta.y = 0;
        }
        if (pitaakoSeurata && !ollaankoLyontiEtaisyydella)

        {
            transform.LookAt(pelaaja.transform);
            rb.AddForce(seurausSuunta.normalized * kiihtyvyys);
        }
        if (rb.velocity.magnitude > maxNopeus)
        {
            rb.velocity = rb.velocity.normalized * maxNopeus;
        }
	}
}
