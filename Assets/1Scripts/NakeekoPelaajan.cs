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

    bool OnkoNakoKentassa()
    {
        Vector3 suuntaPelaajaan = pelaaja.transform.position - transform.position;
        float kulma = Mathf.Atan2(suuntaPelaajaan.x, suuntaPelaajaan.z) + Mathf.PI;
        float rot = (transform.rotation.eulerAngles.y) * Mathf.Deg2Rad;
        Vector3 suuntaRotPlus = new Vector3(Mathf.Sin(rot + nakoAlue), 0, Mathf.Cos(rot + nakoAlue));
        Vector3 suuntaRotMiinus = new Vector3(Mathf.Sin(rot - nakoAlue), 0, Mathf.Cos(rot - nakoAlue));
        Debug.DrawRay(transform.position, suuntaPelaajaan);
        Debug.DrawRay(transform.position, suuntaRotPlus);
        Debug.DrawRay(transform.position, suuntaRotMiinus);
        Debug.Log("Kulma " + kulma * Mathf.Deg2Rad);
        Debug.Log("Rot " + rot * Mathf.Deg2Rad);

        //Debug.Log("Rot - nakoAlue: " + (rot + nakoAlue) * Mathf.Rad2Deg);
        //Debug.Log("Rot + nakoAlue: " + (rot - nakoAlue) * Mathf.Rad2Deg);
        return true;
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
