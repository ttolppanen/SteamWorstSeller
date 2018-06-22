using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torjuminen : MonoBehaviour {

    public bool torjutaanko;
    public float staminanPalautusMaara;
    public float staminanVahennysMaara;
    Stamina sScripti;

    private void Start()
    {
        sScripti = GetComponent<Stamina>();
    }

    private void Update()
    {
        torjutaanko = false;
        if (Input.GetMouseButton(1))
        {
            torjutaanko = true;
            sScripti.VahennaStaminaa(Time.deltaTime * staminanVahennysMaara);
        }
        else
        {
            sScripti.PalautaStaminaa(Time.deltaTime * staminanPalautusMaara);
        }
    }
}
