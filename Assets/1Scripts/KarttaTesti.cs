using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarttaTesti : MonoBehaviour {

    Material materiaali;
    public GameObject vertailuReuna;
    public float tasausKerroin;
    GameObject pelaaja;

	void Start () {
        materiaali = GetComponent<SpriteRenderer>().material;
        pelaaja = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
        Vector3 suuntaVertailusta = pelaaja.transform.position - vertailuReuna.transform.position;
        suuntaVertailusta = new Vector2(suuntaVertailusta.x, suuntaVertailusta.z) / tasausKerroin;
        materiaali.SetVector("keskiPaikka", suuntaVertailusta);
	}
}
