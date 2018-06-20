using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemeidenSiirto : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    UiHallinta uhScripti;
    Inventory iScripti; //Inventorio scripti
    GraphicRaycaster raycaster;
    GameObject[,] pelaajanInventory;
    Vector2Int mK; //Meidän koordinaatit


    private void Start()
    {
        uhScripti = GameObject.Find("UiMainCanvas").GetComponent<UiHallinta>();
        raycaster = GameObject.Find("UiMainCanvas").GetComponent<GraphicRaycaster>();
        iScripti = GameObject.Find("PelaajanInventory").GetComponent<Inventory>();
        pelaajanInventory = iScripti.inventory;
        mK = new Vector2Int(int.Parse(char.ToString(transform.name[0])), int.Parse(char.ToString(transform.name[1])));//Haetaan nimestä koordinaatit...
    }

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {

        }
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        if (uhScripti.esineHiirenKannossa == null)
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

        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(eventData, results);
        GameObject toinenPalikka = loydaEsine(results);

        bool ollaankoInvAlueella = ((RectTransform)transform.parent).rect.Contains(Input.mousePosition);//Parentti on se missä on kaikki blockit, katotaan ollaanok sen sisällä
        if (!ollaankoInvAlueella)
        {
            iScripti.TiputaInventorysta(mK);
            return;
        }

        if (toinenPalikka != null)
        {
            //Vaihdetaan paikat pelaajan inventoryssä...
            Vector2Int tK = new Vector2Int(int.Parse(char.ToString(toinenPalikka.transform.name[0])), int.Parse(char.ToString(toinenPalikka.transform.name[1])));
            GameObject toinenPeliObjekti = pelaajanInventory[tK.x, tK.y];
            pelaajanInventory[tK.x, tK.y] = pelaajanInventory[mK.x, mK.y];
            pelaajanInventory[mK.x, mK.y] = toinenPeliObjekti;
        }
        
        uhScripti.esineHiirenKannossa.transform.position = uhScripti.esineHiirenKannossa.transform.parent.position;
        uhScripti.esineHiirenKannossa = null;
    }

    GameObject loydaEsine(List<RaycastResult> lista)
    {
        foreach (RaycastResult i in lista)
        {
            if (i.gameObject.tag == "InventoryPalikka")
            {
                return i.gameObject;
            }
        }
        return null;
    }

}
