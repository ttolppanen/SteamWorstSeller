using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBAR : MonoBehaviour {

    Stamina sScripti;
    float maxStamina;
    float staminaHp;
    Image staminaBarKuva;

    private void Start()
    {
        sScripti = GameObject.FindGameObjectWithTag("Player").GetComponent<Stamina>();
        staminaBarKuva = GetComponent<Image>();
        maxStamina = sScripti.maxStamina;
    }

    private void Update()
    {
        staminaHp = sScripti.staminaHp;
        staminaBarKuva.fillAmount = staminaHp / maxStamina;
    }
}
