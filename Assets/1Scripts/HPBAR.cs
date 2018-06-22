using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBAR : MonoBehaviour {


    PelaajanElama peScripti;
    float maxHP;
    float hp;
    Image hpBarKuva;

    private void Start()
    {
        peScripti = GameObject.FindGameObjectWithTag("Player").GetComponent<PelaajanElama>();
        hpBarKuva = GetComponent<Image>();
        maxHP = peScripti.maxHP;
    }

    private void Update()
    {
        hp = peScripti.hp;
        hpBarKuva.fillAmount = hp / maxHP;
    }

}
