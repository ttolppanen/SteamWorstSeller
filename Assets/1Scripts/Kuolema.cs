using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kuolema : MonoBehaviour {

    Elama eScripti;

	void Start () {
        eScripti = GetComponent<Elama>();
	}
	
	void Update () {
        bool onkoKuollut = eScripti.onkoKuollut;
        if (onkoKuollut)
        {
            Destroy(gameObject);
        }
	}
}
