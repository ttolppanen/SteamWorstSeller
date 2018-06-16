using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyoVihollista : MonoBehaviour {

    GameObject aseObjecti;
    Ase ase; //Itse ase

    private void Start()
    {
        aseObjecti = GameObject.Find("AseenPaikka").transform.GetChild(0).gameObject;
    }

    void Update () {
        ase = (Ase)aseObjecti.GetComponent<EsineenOminaisuuksia>().esine;
        ase.animaatiot = GetComponent<Animator>();
        if (Input.GetMouseButtonDown(0))
        {
            ase.Lyo();
        }	
	}
}
