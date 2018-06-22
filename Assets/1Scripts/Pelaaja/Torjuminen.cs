using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torjuminen : MonoBehaviour {

    public bool torjutaanko;
    public float staminanPalautusMaara;
    public float staminanVahennysMaara;
    public float parryAika;
    public float parryCooldown;
    bool voidaankoParryta;
    public bool onkoParryPaalla;

    Stamina sScripti;

    private void Start()
    {
        sScripti = GetComponent<Stamina>();
        voidaankoParryta = true;
        onkoParryPaalla = false;
    }

    private void Update()
    {
        torjutaanko = false;
        if (Input.GetMouseButton(1))
        {
            torjutaanko = true;
            sScripti.VahennaStaminaa(Time.deltaTime * staminanVahennysMaara);
        }
        if (Input.GetMouseButtonDown(1) && voidaankoParryta)
        {
            onkoParryPaalla = true;
            voidaankoParryta = false;
            StartCoroutine(ParryAika());
        }
        else
        {
            sScripti.PalautaStaminaa(Time.deltaTime * staminanPalautusMaara);
        }
    }

    IEnumerator ParryAika()
    {
        yield return new WaitForSeconds(parryAika);
        onkoParryPaalla = false;
        StartCoroutine(ParryCooldown());
    }

    IEnumerator ParryCooldown()
    {
        yield return new WaitForSeconds(parryCooldown);
        voidaankoParryta = true;
    }
}
