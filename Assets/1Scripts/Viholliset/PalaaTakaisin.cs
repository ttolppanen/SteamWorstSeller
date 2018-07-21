using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalaaTakaisin : MonoBehaviour {

    public float tallennusAika;

    List<Vector4> viimeisetPisteet = new List<Vector4>();
    Vector3 startingPoint;
    float aika;
    Rigidbody rb;
    float kiihtyvyys;
    EnStates states;


    void Start () {
        states = GetComponent<EnStates>();
        rb = GetComponent<Rigidbody>();
        kiihtyvyys = GetComponent<vihollistenLiikuminen>().kiihtyvyys;
        startingPoint = transform.position;
	}

    void Update() {
        if (states.isFollowing)
        {
            TallennaPisteet();
        }
        else
        {
            PalaaTakaisinAlkuun();
        }
        states.isReturning = viimeisetPisteet.Count != 0;
	}


    void TallennaPisteet()
    {
        if (viimeisetPisteet.Count == 0)
        {
            viimeisetPisteet.Add(startingPoint);
        }
        else if (Time.time - viimeisetPisteet[viimeisetPisteet.Count - 1].w > tallennusAika)
        {
            Vector4 tallennettavaPiste = new Vector4(transform.position.x, 0, transform.position.z, Time.time);
            viimeisetPisteet.Add(tallennettavaPiste);
        }
    }

    void PalaaTakaisinAlkuun()
    {
        if (viimeisetPisteet.Count == 0)
        {
            return;
        }

        Vector3 viimeisinPiste = viimeisetPisteet[viimeisetPisteet.Count - 1];
        if (Mathf.Round(transform.position.x) == Mathf.Round(viimeisinPiste.x) && Mathf.Round(transform.position.z) == Mathf.Round(viimeisinPiste.z))
        {
            if (viimeisetPisteet.Count > 0)
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
