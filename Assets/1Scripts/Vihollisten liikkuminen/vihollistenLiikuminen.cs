using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vihollistenLiikuminen : MonoBehaviour {

    public float kiihtyvyys;
    public float maxNopeus;
    GameObject pelaaja;
    Rigidbody rb;
    NakeekoPelaajan nkScripti;
    VihollisenSeuraus vhScripti;
    Vector3 seurausSuunta;

	void Start () {
        rb = GetComponent<Rigidbody>();
        pelaaja = GameObject.FindGameObjectWithTag("Player");
        nkScripti = GetComponent<NakeekoPelaajan>();
        vhScripti = GetComponent<VihollisenSeuraus>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        bool nahdaankoPelaaja = nkScripti.nahdaankoPelaaja;
        bool pitaakoSeurata = vhScripti.pitaakoSeurata;
        if (nahdaankoPelaaja)
        {
            seurausSuunta = (pelaaja.transform.position - transform.position).normalized;
            seurausSuunta.y = 0;
        }
        if (pitaakoSeurata)
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
