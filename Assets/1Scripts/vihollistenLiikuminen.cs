using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vihollistenLiikuminen : MonoBehaviour {

    public float liikkumisNopeus;
    GameObject pelaaja;
    Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
        pelaaja = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 suuntaPelaajaan = pelaaja.transform.position - transform.position;
        suuntaPelaajaan.y = 0;
        rb.AddForce(suuntaPelaajaan.normalized * liikkumisNopeus);
	}
}
