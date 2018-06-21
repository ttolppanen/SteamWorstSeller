using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtaisyysValoon : MonoBehaviour {

    Material materiaali;

	void Start () {
        materiaali = GetComponent<SpriteRenderer>().material;
	}
	
	void Update () {
        GameObject[] valot = GameObject.FindGameObjectsWithTag("Valo");
        materiaali.SetFloat("_EtaisyysValoon", EtsiLahinValo(valot));        
	}


    float EtsiLahinValo(GameObject[] valot)
    {
        float etaisyys = 10000;
        foreach (GameObject valo in valot)
        {
            float etaisyysValoon = (transform.position - valo.transform.position).magnitude;
            if (etaisyysValoon < etaisyys)
            {
                etaisyys = etaisyysValoon;
            }
        }
        return etaisyys;
    }
}
