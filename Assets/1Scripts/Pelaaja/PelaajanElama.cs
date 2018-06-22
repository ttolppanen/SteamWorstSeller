using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelaajanElama : MonoBehaviour {

    public float maxHP;
    public bool onkoKuollut;
    public float hp;

    Torjuminen tScripti;

    private void Start()
    {
        hp = maxHP;
        onkoKuollut = false;
        tScripti = GetComponent<Torjuminen>();
    }

    public void OtaVahinkoa(float vahinko)
    {
        if (tScripti.torjutaanko)
        {

        }
        else
        {
            hp -= vahinko;
            TarkistaOnkoKuollut();
        }
    }

    void TarkistaOnkoKuollut()
    {
        if (hp <= 0)
        {
            onkoKuollut = true;
        }
    }
}
