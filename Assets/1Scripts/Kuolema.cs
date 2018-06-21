using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kuolema : MonoBehaviour {

    public GameObject sielu;
    Elama eScripti;

	void Start () {
        eScripti = GetComponent<Elama>();
	}
	
	void Update () {
        if (eScripti.onkoKuollut)
        {
            Instantiate(sielu, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}
}
