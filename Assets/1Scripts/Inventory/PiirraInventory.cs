using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiirraInventory : MonoBehaviour {

    GameObject[,] inventory; 
    Inventory ivScripti; //Inventorio scripti
    public Vector2Int koordinaatit; // 0, 0 on vasen yläreuna
    Sprite kuva;
    Sprite tyhjaKuva;

    private void Awake()
    {
        ivScripti = GameObject.Find("PelaajanInventory").GetComponent<Inventory>();
        Texture2D tyhja = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        tyhja.SetPixel(0, 0, Color.clear);
        tyhja.Apply();
        tyhjaKuva = Sprite.Create(tyhja, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f));
    }

    void Update () {
        inventory = ivScripti.inventory;
        PiirraKuva();
	}

    void PiirraKuva()
    {
        if (inventory[koordinaatit.x, koordinaatit.y] != null)
        {
            kuva = inventory[koordinaatit.x, koordinaatit.y].GetComponent<EsineenOminaisuuksia>().esine.kuva; //Haetaan kuva EsineenOminaisuudet scriptistä.
            GetComponent<Image>().sprite = kuva;
        }
        else
        {
            GetComponent<Image>().sprite = tyhjaKuva;
        }
    }

}
