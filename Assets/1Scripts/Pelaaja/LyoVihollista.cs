using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyoVihollista : MonoBehaviour {

    public GameObject aseenPaikka;
    Weapon weapon; //Itse ase


    void Update () {
        if (aseenPaikka.transform.childCount == 0)
        {
            return;
        }
        weapon = (Weapon)aseenPaikka.transform.GetChild(0).GetComponent<ItemProperties>().item;
        weapon.animator = GetComponent<Animator>();
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Hit();
        }	
	}
}
