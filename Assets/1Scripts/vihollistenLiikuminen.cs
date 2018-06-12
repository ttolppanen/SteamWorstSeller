using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vihollistenLiikuminen : MonoBehaviour {

    public float liikkumisNopeus;
    GameObject pelaaja;
    Rigidbody rb;
    NakeekoPelaajan nkScripti;

	void Start () {
        rb = GetComponent<Rigidbody>();
        pelaaja = GameObject.FindGameObjectWithTag("Player");
        nkScripti = GetComponent<NakeekoPelaajan>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        bool nahdaankoPelaaja = nkScripti.nahdaankoPelaaja;
        if (nahdaankoPelaaja)
        {
            Vector3 suuntaPelaajaan = pelaaja.transform.position - transform.position;
            suuntaPelaajaan.y = 0;
            transform.LookAt(pelaaja.transform);
            rb.AddForce(suuntaPelaajaan.normalized * liikkumisNopeus);
        }
	}
}
