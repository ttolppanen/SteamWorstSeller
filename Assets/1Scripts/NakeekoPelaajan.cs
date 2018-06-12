using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NakeekoPelaajan : MonoBehaviour {

    public bool nahdaankoPelaaja;
    public float nakoAlue; //Asteina +-
    public float nakoMatka;
    public float sektorinSiirto;
    GameObject pelaaja;

    void Start() {
        pelaaja = GameObject.FindGameObjectWithTag("Player");
        sektorinSiirto *= Mathf.Deg2Rad;
        nakoAlue *= Mathf.Deg2Rad;
    }

    void Update() {
        Vector3 suuntaPelaajaan = pelaaja.transform.position - transform.position;
        if (OnkoNakoKentassa() && suuntaPelaajaan.magnitude < nakoMatka && !OnkoJotainEdessa(suuntaPelaajaan))
        {
            nahdaankoPelaaja = true;
        }
        else
        {
            nahdaankoPelaaja = false;
        }
    }

    bool OnkoJotainEdessa(Vector3 suunta)
    {
        Ray sade = new Ray(transform.position, suunta);
        RaycastHit[] osumat = Physics.RaycastAll(sade, nakoMatka);
        osumat = JarjestaPituudenMukaan(osumat);
        foreach (RaycastHit osuma in osumat)
        {
            if (osuma.transform != transform)
            {
                if (osuma.transform != pelaaja.transform)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;
    }

    bool NormaaliNakoKentta(float kulma, float rot)
    {
        if (kulma > rot - nakoAlue && kulma < rot + nakoAlue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool OnkoNakoKentassa()
    {
        Vector3 suuntaPelaajaan = pelaaja.transform.position - transform.position;
        float kulma = Mathf.Atan2(suuntaPelaajaan.x, suuntaPelaajaan.z);
        float rot = (transform.rotation.eulerAngles.y);
        if (rot > 180)
        {
            rot -= 360;
        }
        rot *= Mathf.Deg2Rad;
        if (rot + nakoAlue > Mathf.PI)
        {
            if (kulma < 0)
            {
                kulma += 2 * Mathf.PI;
            }
            return NormaaliNakoKentta(kulma, rot);
        }
        else if (rot - nakoAlue < -Mathf.PI)
        {
            if (kulma >= 0)
            {
                kulma -= 2 * Mathf.PI;
            }
            return NormaaliNakoKentta(kulma, rot);
        }
        return NormaaliNakoKentta(kulma, rot);
    }

    RaycastHit[] JarjestaPituudenMukaan(RaycastHit[] osumat)//JOS ON TÄMÄ LAGAA NIIN LOYTYY HELPPO RATKAISUööööööööö
    {
        List<RaycastHit> jarjestettuLista = new List<RaycastHit>();
        foreach (RaycastHit osuma in osumat)
        {
            float etaisyys = osuma.distance;
            if (jarjestettuLista.Count == 0)
            {
                jarjestettuLista.Add(osuma);
            }
            else
            {
                for(int i = 0; i < jarjestettuLista.Count; i++)
                {
                    if (etaisyys < jarjestettuLista[i].distance)
                    {
                        jarjestettuLista.Insert(i, osuma);
                        break;
                    }
                }
            }
        }
        return jarjestettuLista.ToArray();
    }
}
