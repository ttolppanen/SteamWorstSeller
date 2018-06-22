using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyoPelaajaa : MonoBehaviour {

	public bool ollaankoLyontiEtaisyydella;
    public float lyontiEtaisyys;
    NakeekoPelaajan npScripti;
    Animator animaatiot;

    GameObject pelaaja;

    private void Start()
    {
        pelaaja = GameObject.FindGameObjectWithTag("Player");
        animaatiot = GetComponent<Animator>();
        npScripti = GetComponent<NakeekoPelaajan>();
    }

    private void Update()
    {
        float etaisyys = (new Vector2(pelaaja.transform.position.x, pelaaja.transform.position.z) - new Vector2(transform.position.x, transform.position.z)).magnitude;
        if (etaisyys <= lyontiEtaisyys && npScripti.nahdaankoPelaaja)
        {
            ollaankoLyontiEtaisyydella = true;
            transform.LookAt(pelaaja.transform);
            animaatiot.SetBool("Pitääkö lyödä", true);
        }
        else
        {
            ollaankoLyontiEtaisyydella = false;
            animaatiot.SetBool("Pitääkö lyödä", false);
        }
    }

}
