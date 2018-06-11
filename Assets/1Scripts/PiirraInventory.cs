using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiirraInventory : MonoBehaviour {

    GameObject[,] inventory; 
    Inventory ivScripti; //Inventorio scripti
    public Vector2Int koordinaatit; // 0, 0 on vasen yläreuna
    Sprite kuva;

    private void Start()
    {
        ivScripti = GameObject.Find("PelaajanInventory").GetComponent<Inventory>();
    }

    void Update () {
        inventory = ivScripti.inventory;
        PiirraKuva();
	}

    void PiirraKuva()
    {
        if (inventory[koordinaatit.x, koordinaatit.y] != null)
        {
            kuva = inventory[koordinaatit.x, koordinaatit.y].GetComponent<EsineenOminaisuuksia>().esineenKuva; //Haetaan kuva EsineenOminaisuudet scriptistä.
            GetComponent<Image>().sprite = kuva;
        }
        else
        {
            GetComponent<Image>().sprite = null;
        }
    }

}
