using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalaaTakaisin : MonoBehaviour {

    public float tallennusAika;

    List<Vector4> viimeisetPisteet = new List<Vector4>();
    VihollisenSeuraus vhScripti;
    float aika;
    Rigidbody rb;
    float kiihtyvyys;


    void Start () {
        viimeisetPisteet.Add(transform.position);
        print(viimeisetPisteet[0].w);
        vhScripti = GetComponent<VihollisenSeuraus>();
        rb = GetComponent<Rigidbody>();
        kiihtyvyys = GetComponent<vihollistenLiikuminen>().kiihtyvyys;
	}

	void Update () {
        bool pitaakoSeurata = vhScripti.pitaakoSeurata;
        if (pitaakoSeurata)
        {
            TallennaPisteet();
        }
        else
        {
            PalaaTakaisinAlkuun();
        }
	}


    void TallennaPisteet()
    {
        if (Time.time - viimeisetPisteet[viimeisetPisteet.Count - 1].w > tallennusAika)
        {
            Vector4 tallennettavaPiste = new Vector4(transform.position.x, 0, transform.position.z, Time.time);
            viimeisetPisteet.Add(tallennettavaPiste);
        }
    }

    void PalaaTakaisinAlkuun()
    {
        Vector3 viimeisinPiste = viimeisetPisteet[viimeisetPisteet.Count - 1];
        if (Mathf.Round(transform.position.x) == Mathf.Round(viimeisinPiste.x) && Mathf.Round(transform.position.z) == Mathf.Round(viimeisinPiste.z))
        {
            if (viimeisetPisteet.Count > 1)
            {
                viimeisetPisteet.RemoveAt(viimeisetPisteet.Count - 1);
            }
        }
        else
        {
            Vector3 suunta = (viimeisinPiste - transform.position).normalized;
            suunta.y = 0;
            rb.AddForce(suunta * kiihtyvyys);
        }
    }
}
