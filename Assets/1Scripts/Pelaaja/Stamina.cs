using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour {

    public float maxStamina;
    public float staminaHp;
    public float staminanPalautusMaara;
    public float staminanPalautusAika;
    float staminaViimeFramessa;
    float aika;

    private void Start()
    {
        staminaHp = maxStamina;
        staminaViimeFramessa = staminaHp;
    }

    private void Update()
    {
        if (staminaHp != staminaViimeFramessa)
        {
            aika = 0;
        }
        if (aika >= staminanPalautusAika)
        {
            PalautaStaminaa(staminanPalautusMaara * Time.deltaTime);
        }
        aika += Time.deltaTime;
        staminaViimeFramessa = staminaHp;
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

    public bool SaadaankoKayttaaStaminaa(float vahennysMaara)
    {
        if (staminaHp - vahennysMaara < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
