using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class katsoPelaajaPain : MonoBehaviour {

    GameObject pelaaja;

	void Start () {
        pelaaja = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(pelaaja.transform);
	}
}
