using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VihollistenHurtBox : MonoBehaviour {

    public float damage;
    public bool parryykoPelaaja;
    public bool pitaakoTarkistaaParry;
    public GameObject stunTahdet;
    public Transform stunTahdetSpawnPaikka;

    Torjuminen tScripti;

    private void Start()
    {
        pitaakoTarkistaaParry = false;
        tScripti = GameObject.FindWithTag("Player").GetComponent<Torjuminen>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (tScripti.onkoParryPaalla && pitaakoTarkistaaParry)
            {
                Instantiate(stunTahdet, stunTahdetSpawnPaikka.position, Quaternion.identity);
                Animator animaatiot = transform.parent.GetComponent<Animator>();
                animaatiot.SetTrigger("Stunned");
            }
            else
            {
                other.GetComponent<PelaajanElama>().OtaVahinkoa(damage);
            }
            gameObject.SetActive(false);
        }
    }
}