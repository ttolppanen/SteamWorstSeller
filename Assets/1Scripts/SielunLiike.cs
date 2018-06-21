using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SielunLiike : MonoBehaviour {

    public float nopeusKerroin;
    Vector3 paikkaAlussa;
    Rigidbody rb;

    private void Start()
    {
        paikkaAlussa = transform.position;
        paikkaAlussa.y = 4;
        rb = GetComponent<Rigidbody>();
    }

    void Update () {
        Vector3 suunta = paikkaAlussa - transform.position;
        rb.AddForce(suunta * nopeusKerroin);
        rb.drag = rb.velocity.magnitude;
	}
}
