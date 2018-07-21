using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyoPelaajaa : MonoBehaviour {

    public float lyontiEtaisyys;
    EnStates states;
    Animator animaatiot;

    GameObject pelaaja;

    private void Start()
    {
        pelaaja = GameObject.FindGameObjectWithTag("Player");
        animaatiot = GetComponent<Animator>();
        states = GetComponent<EnStates>();
    }

    private void Update()
    {
        float etaisyys = (new Vector2(pelaaja.transform.position.x, pelaaja.transform.position.z) - new Vector2(transform.position.x, transform.position.z)).magnitude;
        if (etaisyys <= lyontiEtaisyys && states.seesPlayer)
        {
            states.inHittingRange = true;
            transform.LookAt(pelaaja.transform);
            animaatiot.SetBool("Pitääkö lyödä", true);
        }
        else
        {
            states.inHittingRange = false;
            animaatiot.SetBool("Pitääkö lyödä", false);
        }
    }

}
