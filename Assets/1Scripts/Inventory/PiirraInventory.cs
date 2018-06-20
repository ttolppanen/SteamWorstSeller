using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiirraInventory : MonoBehaviour {

    Inventory ivScripti; //Inventorio scripti
    Sprite kuva;
    Sprite tyhjaKuva;
    public Vector2Int koordinaatit;
    int koordinaatitInt;

    private void Awake()
    {
        ivScripti = GameObject.Find("PelaajanInventory").GetComponent<Inventory>();
        Texture2D tyhja = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        tyhja.SetPixel(0, 0, Color.clear);
        tyhja.Apply();
        tyhjaKuva = Sprite.Create(tyhja, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f));
        koordinaatit = new Vector2Int(int.Parse(char.ToString(transform.parent.name[0])), int.Parse(char.ToString(transform.parent.name[1])));//Haetaan emon nimestä koordinaatit...
    }

    void Update () {
        PiirraKuva();
	}

    void PiirraKuva()
    {
        if (ivScripti.inventory[koordinaatit.x, koordinaatit.y] != null)
        {
            kuva = ivScripti.inventory[koordinaatit.x, koordinaatit.y].GetComponent<EsineenOminaisuuksia>().esine.inventoryKuva; //Haetaan kuva EsineenOminaisuudet scriptistä.
            GetComponent<Image>().sprite = kuva;
        }
        else
        {
            GetComponent<Image>().sprite = tyhjaKuva;
        }
    }

}
