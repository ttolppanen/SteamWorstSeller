using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NakeekoPelaajan : MonoBehaviour {

    public bool nahdaankoPelaaja;
    public float nakoAlue; //Asteina +-
    public float nakoMatka;
    GameObject pelaaja;

    void Start() {
        pelaaja = GameObject.FindGameObjectWithTag("Player");
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
        osumat = Functions.SortByLenght(osumat);
        foreach (RaycastHit osuma in osumat)
        {
            if (osuma.transform != transform && osuma.transform.tag != "Enemy")
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
        Vector3 suuntaPelaajaan = (pelaaja.transform.position - transform.position).normalized;
        float pelaajanJaVihollisenValinenKulma = Mathf.Acos(Vector3.Dot(suuntaPelaajaan, transform.forward));
       
        if (pelaajanJaVihollisenValinenKulma > -nakoAlue && pelaajanJaVihollisenValinenKulma < nakoAlue || float.IsNaN(pelaajanJaVihollisenValinenKulma))
        {
            return true;
        }
        else {
            return false;
        }


        /*VANHA
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
        return NormaaliNakoKentta(kulma, rot);*/
    }
}