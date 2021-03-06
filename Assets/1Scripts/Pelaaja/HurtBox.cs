﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour {

    public GameObject veri;
    public Vector3 verenSuunta; //Suunta vektorina
    public float kuinkaEteenVeriSpawnaa;

    float damage;
    public  GameObject kasi; //Käsi

    private void Start()
    {
        kasi = GameObject.Find("AseenPaikka");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            damage = ((Weapon)kasi.transform.GetChild(0).GetComponent<ItemProperties>().item).damage;
            Vector3 suuntaVihollisestaPelaajaan = (transform.position - other.transform.position).normalized;
            other.GetComponent<Elama>().OtaVahinkoa(damage);
            Instantiate(veri, other.transform.position + suuntaVihollisestaPelaajaan * kuinkaEteenVeriSpawnaa, Quaternion.LookRotation(verenSuunta, new Vector3(0, 1, 0)));
            gameObject.SetActive(false);
        }
    }
}