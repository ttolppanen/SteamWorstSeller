using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiirraInventory : MonoBehaviour {

    Inventory ivScripti; //Inventorio scripti
    GameObject[,] pelaajanInventory;
    GameObject[] pelaajanVarustus;
    Sprite kuva;
    Sprite tyhjaKuva;
    public Vector2Int koordinaatit;
    int varusteIndeksi;

    private void Awake()
    {
        varusteIndeksi = 69; //69 on tarkistus numero!!!
        ivScripti = GameObject.Find("PelaajanInventory").GetComponent<Inventory>();
        pelaajanInventory = ivScripti.inventory;
        pelaajanVarustus = ivScripti.equipment;

        Texture2D tyhja = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        tyhja.SetPixel(0, 0, Color.clear);
        tyhja.Apply();
        tyhjaKuva = Sprite.Create(tyhja, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f));

        if (char.ToString(transform.parent.name[0]) == "V")//pitää miettiä tämä!!!
        {
            varusteIndeksi = int.Parse(char.ToString(transform.parent.name[1]));
        }
        else
        {
            koordinaatit = new Vector2Int(int.Parse(char.ToString(transform.parent.name[0])), int.Parse(char.ToString(transform.parent.name[1])));//Haetaan emon nimestä koordinaatit...
        }
    }

    void Update () {
        PiirraKuva();
	}

    void PiirraKuva()
    {
        if (varusteIndeksi == 69)
        {
            if (pelaajanInventory[koordinaatit.x, koordinaatit.y] != null)
            {
                kuva = pelaajanInventory[koordinaatit.x, koordinaatit.y].GetComponent<ItemProperties>().item.inventoryPicture; //Haetaan kuva EsineenOminaisuudet scriptistä.
                GetComponent<Image>().sprite = kuva;
            }
            else
            {
                GetComponent<Image>().sprite = tyhjaKuva;
            }
        }
        else
        {
            if (pelaajanVarustus[varusteIndeksi] != null)
            {
                kuva = pelaajanVarustus[varusteIndeksi].GetComponent<ItemProperties>().item.inventoryPicture; //Haetaan kuva EsineenOminaisuudet scriptistä.
                GetComponent<Image>().sprite = kuva;
            }
            else
            {
                GetComponent<Image>().sprite = tyhjaKuva;
            }
        }
    }

}
