using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelaajanElama : MonoBehaviour {

    public float maxHP;
    public bool onkoKuollut;
    public float hp;

    Torjuminen tScripti;
    Stamina sScripti;

    private void Start()
    {
        hp = maxHP;
        onkoKuollut = false;
        tScripti = GetComponent<Torjuminen>();
        sScripti = GetComponent<Stamina>();
    }

    public void OtaVahinkoa(float vahinko)
    {
        if (tScripti.torjutaanko)
        {
            if (sScripti.staminaHp - vahinko < 0)
            {
                hp -= (vahinko - sScripti.staminaHp);
                TarkistaOnkoKuollut();
                sScripti.staminaHp = 0;
            }
            else
            {
                sScripti.VahennaStaminaa(vahinko);
            }
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
