using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour {

    public GameObject veri;
    public Vector3 verenSuunta; //Suunta vektorina

    float vahinko;
    public  GameObject kasi; //Käsi

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
            Instantiate(veri, other.transform.position, Quaternion.LookRotation(verenSuunta, new Vector3(0, 1, 0)));
            gameObject.SetActive(false);
        }
    }
}