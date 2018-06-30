using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelaajanLiikkuminen : MonoBehaviour {

    public float nopeusKerroin;
    [Range(0f, 1f)]
    public float taaksePainKerroin;
    Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey("w")) {
            rb.AddForce(transform.forward * nopeusKerroin);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(-transform.forward * nopeusKerroin * taaksePainKerroin);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-transform.right * nopeusKerroin);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(transform.right * nopeusKerroin);
        }
    }
}
