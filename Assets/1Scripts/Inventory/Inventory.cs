﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject[,] inventory = new GameObject[10, 10];
    public GameObject[] varusteet = new GameObject[5]; //EquipmentType enum....
    public Transform inventorynPaikka;
    public Transform tiputusPaikka;

    public Transform aseenPaikka;

    void Update() {
        /*if (Input.GetMouseButtonDown(1)) {
            for (int iy = 0; iy < inventory.GetLength(0); iy++)
            {
                for (int ix = 0; ix < inventory.GetLength(1); ix++)
                {
                    if (inventory[ix, iy] != null)
                    {
                        TiputaInventorysta(new Vector2Int(ix, iy));
                        return;
                    }
                }
            }
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Esine" && Input.GetKey("f"))
        {
            LaitaEsineTyhjaanPaikkaan(other.transform.parent.gameObject);
            foreach (Collider coll in other.transform.parent.GetComponents<Collider>())
            {
                coll.enabled = false;
            }
        }
    }



    void LaitaEsineTyhjaanPaikkaan(GameObject item) {
        for (int iy = 0; iy < inventory.GetLength(0); iy++)
        {
            for (int ix = 0; ix < inventory.GetLength(1); ix++)
            {
                if (inventory[ix, iy] == null)
                {
                    inventory[ix, iy] = item;
                    inventory[ix, iy].transform.parent = inventorynPaikka;
                    inventory[ix, iy].transform.position = inventorynPaikka.position;
                    inventory[ix, iy].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    return;
                }
            }
        }
    }

    public void TiputaInventorysta(Vector2Int koordinaatit)
    {
        inventory[koordinaatit.x, koordinaatit.y].transform.parent = null;
        inventory[koordinaatit.x, koordinaatit.y].transform.position = tiputusPaikka.position;
        inventory[koordinaatit.x, koordinaatit.y].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        foreach (Collider coll in inventory[koordinaatit.x, koordinaatit.y].GetComponents<Collider>())
        {
            coll.enabled = true;
        }
        inventory[koordinaatit.x, koordinaatit.y] = null;
    }
    public void TiputaInventorysta(int indeksi)
    {
        varusteet[indeksi].transform.parent = null;
        varusteet[indeksi].transform.position = tiputusPaikka.position;
        varusteet[indeksi].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        foreach (Collider coll in varusteet[indeksi].GetComponents<Collider>())
        {
            coll.enabled = true;
        }
        varusteet[indeksi] = null;
    }

    public void PoistaEsineKadesta()
    {
        if (aseenPaikka.childCount == 0)
        {
            return;
        }
        Transform aseKadessa = aseenPaikka.GetChild(0);
        aseKadessa.parent = inventorynPaikka;
        aseKadessa.position = inventorynPaikka.position;
        aseKadessa.localScale = new Vector3(1, 1, 1);
    }
    public void AsetaEsineKateen(GameObject item)
    {
        item.transform.parent = aseenPaikka;
        item.transform.position = aseenPaikka.transform.position;
        item.transform.rotation = aseenPaikka.rotation;
        item.transform.localScale = new Vector3(1, item.transform.localScale.y, item.transform.localScale.z);
    }
}
