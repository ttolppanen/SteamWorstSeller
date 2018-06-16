using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour {

    float vahinko;
    GameObject kasi; //Käsi

    private void Start()
    {
        kasi = GameObject.Find("AseenPaikka");
    }

    private void Update()
    {
        vahinko = ((Ase)kasi.transform.GetChild(0).GetComponent<EsineenOminaisuuksia>().esine).vahinko;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Elama>().OtaVahinkoa(vahinko);
            gameObject.SetActive(false);
        }
    }
}