using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VihollisenSeuraus : MonoBehaviour {

    NakeekoPelaajan npScripti;
    public float seuraamisenLopetusAika;
    public bool pitaakoSeurata;
    float aika;

    private void Start()
    {
        npScripti = GetComponent<NakeekoPelaajan>();
        pitaakoSeurata = false;
    }

    private void Update()
    {
        bool nahdaankoPelaaja = npScripti.nahdaankoPelaaja;
        if (nahdaankoPelaaja)
        {
            pitaakoSeurata = true;
            aika = 0;
        }
        else
        {
            if (aika > seuraamisenLopetusAika)
            {
                pitaakoSeurata = false;
            }
        }
        aika += Time.deltaTime;
    }
}
