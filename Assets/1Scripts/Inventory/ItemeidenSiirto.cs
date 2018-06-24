using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemeidenSiirto : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    //TÄMÄ ON SEKAVASTI TEHTY, VARMAANKIN JOKU FIKSUMPI TAPA ON OLEMASSA MUTTA IHAN SAMA JOS TOIMII

    UiHallinta uhScripti;
    Inventory iScripti; //Inventorio scripti
    GraphicRaycaster raycaster;
    GameObject[,] pelaajanInventory;
    GameObject[] pelaajanVarustus;
    Vector2Int mK; //Meidän koordinaatit
    bool onkoVarustePaikka;
    int mIndeksi; //Meidän indeksi, mikäli ollaan varustepalikka


    private void Start()
    {
        uhScripti = GameObject.Find("UiMainCanvas").GetComponent<UiHallinta>();
        raycaster = GameObject.Find("UiMainCanvas").GetComponent<GraphicRaycaster>();
        iScripti = GameObject.Find("PelaajanInventory").GetComponent<Inventory>();
        pelaajanInventory = iScripti.inventory;
        pelaajanVarustus = iScripti.varusteet;
        if (char.ToString(transform.name[0]) != "V")//Pitää miettiä tämä!!!!
        {
            mK = new Vector2Int(int.Parse(char.ToString(transform.name[0])), int.Parse(char.ToString(transform.name[1])));//Haetaan nimestä koordinaatit...
            onkoVarustePaikka = false;
        }
        else
        {
            mIndeksi = int.Parse(char.ToString(transform.name[1]));
            onkoVarustePaikka = true;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (uhScripti.esineHiirenKannossa == null && ((pelaajanInventory[mK.x, mK.y] != null && !onkoVarustePaikka) || (pelaajanVarustus[mIndeksi] != null && onkoVarustePaikka)))
        {
            uhScripti.esineHiirenKannossa = transform.GetChild(0).gameObject;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (uhScripti.esineHiirenKannossa == null)
        {
            return;
        }
        uhScripti.esineHiirenKannossa.GetComponent<Canvas>().sortingOrder = 2;
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(eventData, results);
        GameObject toinenPalikka = loydaEsine(results);

        if (toinenPalikka == null)
        {
            iScripti.TiputaInventorysta(mK);
            return;
        }

        if (toinenPalikka != null)
        {   
            if (char.ToString(toinenPalikka.name[0]) == "V")//TÄSSÄ EQUIPATAAN, JA SIIS KATSOTAAN ONKO TOINEN PALIKKA VARUSTEPALIKKA
            {
                if (!onkoVarustePaikka && pelaajanInventory[mK.x, mK.y].GetComponent<EsineenOminaisuuksia>().esine is Varuste) //Katsotaanko ollaanko laittamassa päälle varustusta, eikä esim. potionia
                {
                    int varustePalikanIndeksi = int.Parse(char.ToString(toinenPalikka.name[1])); //Peliobjektin nimeen laitettu mikä paikka, 0 on pää, jne menee samalla lailla kun enum VarusteTyyppi
                    int varusteenIndeksi = (int)((Varuste)pelaajanInventory[mK.x, mK.y].GetComponent<EsineenOminaisuuksia>().esine).varusteTyyppi; //Haetaan esineestä varusteTyyppi...

                    if (varustePalikanIndeksi == varusteenIndeksi)
                    {
                        GameObject toinenPeliObjekti = pelaajanVarustus[varustePalikanIndeksi];
                        if (varusteenIndeksi == (int)VarusteTyyppi.Ase)
                        {
                            iScripti.PoistaEsineKadesta();
                            pelaajanVarustus[varustePalikanIndeksi] = pelaajanInventory[mK.x, mK.y];
                            pelaajanInventory[mK.x, mK.y] = toinenPeliObjekti;
                            iScripti.AsetaEsineKateen(pelaajanVarustus[varustePalikanIndeksi]);

                        }
                        else
                        {
                            pelaajanVarustus[varustePalikanIndeksi] = pelaajanInventory[mK.x, mK.y];
                            pelaajanInventory[mK.x, mK.y] = toinenPeliObjekti;
                        }
                    }
                }
            }
            else
            {
                Vector2Int tK = new Vector2Int(int.Parse(char.ToString(toinenPalikka.name[0])), int.Parse(char.ToString(toinenPalikka.transform.name[1])));
                GameObject toinenPeliObjekti = pelaajanInventory[tK.x, tK.y];
                if (onkoVarustePaikka)//TÄSSÄ EQUIPATAAN
                {
                    if (toinenPeliObjekti == null)
                    {
                        if (mIndeksi == (int)VarusteTyyppi.Ase)
                        {
                            iScripti.PoistaEsineKadesta();
                        }
                        pelaajanInventory[tK.x, tK.y] = pelaajanVarustus[mIndeksi];
                        pelaajanVarustus[mIndeksi] = toinenPeliObjekti;
                    }
                    else
                    {
                        if (toinenPeliObjekti.GetComponent<EsineenOminaisuuksia>().esine is Varuste)
                        {
                            int varusteenIndeksi = (int)((Varuste)toinenPeliObjekti.GetComponent<EsineenOminaisuuksia>().esine).varusteTyyppi; //Haetaan esineestä varusteTyyppi...
                            if (varusteenIndeksi == mIndeksi)
                            {
                                if (varusteenIndeksi == (int)VarusteTyyppi.Ase)
                                {
                                    iScripti.PoistaEsineKadesta();
                                    pelaajanInventory[tK.x, tK.y] = pelaajanVarustus[mIndeksi];
                                    pelaajanVarustus[mIndeksi] = toinenPeliObjekti;
                                    iScripti.AsetaEsineKateen(toinenPeliObjekti);

                                }
                                else
                                {
                                    pelaajanInventory[tK.x, tK.y] = pelaajanVarustus[mIndeksi];
                                    pelaajanVarustus[mIndeksi] = toinenPeliObjekti;
                                }
                            }
                        }
                    }
                }
                else
                {
                    //Vaihdetaan paikat pelaajan inventoryssä...
                    pelaajanInventory[tK.x, tK.y] = pelaajanInventory[mK.x, mK.y];
                    pelaajanInventory[mK.x, mK.y] = toinenPeliObjekti;
                }
            }
        }
        uhScripti.esineHiirenKannossa.GetComponent<Canvas>().sortingOrder = 1;
        uhScripti.esineHiirenKannossa.transform.position = uhScripti.esineHiirenKannossa.transform.parent.position;
        uhScripti.esineHiirenKannossa = null;
    }

    GameObject loydaEsine(List<RaycastResult> lista)
    {
        foreach (RaycastResult i in lista)
        {
            if (i.gameObject.tag == "InventoryPalikka")
            {
                print(i.gameObject.name);
                return i.gameObject;
            }
        }
        return null;
    }

}
