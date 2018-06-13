using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemeidenSiirto : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{

    Vector3 aloitusPaikka;

    GraphicRaycaster raycaster;
    PointerEventData pointer;
    EventSystem eventSystem;
    GameObject[,] pelaajanInventory;
    RectTransform invBlockit;
    Inventory invScripti;

    void Awake()
    {
        raycaster = GameObject.Find("Canvas").GetComponent<GraphicRaycaster>();
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        invScripti = GameObject.Find("PelaajanInventory").GetComponent<Inventory>();
        pelaajanInventory = invScripti.inventory;
        invBlockit = (RectTransform)GameObject.Find("InventoryBlockit").transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        aloitusPaikka = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = aloitusPaikka;
        pointer = new PointerEventData(eventSystem);
        pointer.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(eventData, results);
        GameObject toinenPalikka = loydaEsine(results);

        Vector2Int mK = GetComponent<PiirraInventory>().koordinaatit; //Meidän palikan koordinaatit

        bool ollaankoInvAlueella = invBlockit.rect.Contains(Input.mousePosition);

        if (!ollaankoInvAlueella)
        {
            invScripti.TiputaInventorysta(mK);
            return;
        }

        Vector2Int tK = toinenPalikka.GetComponent<PiirraInventory>().koordinaatit; //Toisen palikan koordinaatit
        if (toinenPalikka != null)
        {
            //Vaihdetaan paikat pelaajan inventoryssä...
            GameObject toinenPeliObjekti = pelaajanInventory[tK.x, tK.y];
            pelaajanInventory[tK.x, tK.y] = pelaajanInventory[mK.x, mK.y];
            pelaajanInventory[mK.x, mK.y] = toinenPeliObjekti;
        }
        else
        {
            pelaajanInventory[tK.x, tK.y] = pelaajanInventory[mK.x, mK.y];
            pelaajanInventory[mK.x, mK.y] = null;
        }
    }

    GameObject loydaEsine(List<RaycastResult> lista)
    {
        foreach (RaycastResult i in lista) {
            if (i.gameObject.tag == "InventoryPalikka")
            {
                return i.gameObject;
            }
        }
        return null;
    }

}