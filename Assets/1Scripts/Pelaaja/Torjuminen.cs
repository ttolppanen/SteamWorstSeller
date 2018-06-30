using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torjuminen : MonoBehaviour {

    public bool torjutaanko;
    public float staminanVahennysMaara;
    public float parryAika;
    public float parryCooldown;
    bool voidaankoParryta;
    public bool onkoParryPaalla;
    GameObject oikeaKasi;

    Stamina sScripti;

    private void Start()
    {
        sScripti = GetComponent<Stamina>();
        oikeaKasi = GameObject.Find("OikeaKäsi");
        voidaankoParryta = true;
        onkoParryPaalla = false;
        torjutaanko = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ((Weapon)oikeaKasi.GetComponentInChildren<ItemProperties>().item).BeginBlocking();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            ((Weapon)oikeaKasi.GetComponentInChildren<ItemProperties>().item).StopBlocking();
        }
        if (Input.GetMouseButtonDown(1) && voidaankoParryta)
        {
            onkoParryPaalla = true;
            voidaankoParryta = false;
            StartCoroutine(ParryAika());
        }

        if (torjutaanko)
        {
            sScripti.VahennaStaminaa(Time.deltaTime * staminanVahennysMaara);
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
