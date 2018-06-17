using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyoVihollista : MonoBehaviour {

    public GameObject aseenPaikka;
    Ase ase; //Itse ase


    void Update () {
        ase = (Ase)aseenPaikka.transform.GetChild(0).GetComponent<EsineenOminaisuuksia>().esine;
        ase.animaatiot = GetComponent<Animator>();
        if (Input.GetMouseButtonDown(0))
        {
            ase.Lyo();
        }	
	}
}
