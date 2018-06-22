using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour {

    public float maxStamina;
    public float staminaHp;

    private void Start()
    {
        staminaHp = maxStamina;
    }

    public void VahennaStaminaa(float vahennysMaara)
    {
        staminaHp -= vahennysMaara;
        if (staminaHp < 0)
        {
            staminaHp = 0;
        }
    }

    public void PalautaStaminaa(float palautusMaara)
    {
        staminaHp += palautusMaara;
        if (staminaHp > maxStamina)
        {
            staminaHp = maxStamina;
        }
    }
}
