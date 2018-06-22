﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBAR : MonoBehaviour {

    public GameObject emo;

    Elama eScripti;
    float maxHP;
    float hp;
    Image hpBarKuva;

    private void Start()
    {
        eScripti = emo.GetComponent<Elama>();
        hpBarKuva = GetComponent<Image>();
        maxHP = eScripti.maxHP;
    }

    private void Update()
    {
        hp = eScripti.hp;
        hpBarKuva.fillAmount = hp / maxHP;
    }

}
