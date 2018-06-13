﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject[,] inventory = new GameObject[10, 10];
    public Transform inventorynPaikka;
    public Transform tiputusPaikka;

	void Start () {
		
	}
	
	void Update () {
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
            LaitaEsineTyhjaanPaikkaan(other.gameObject);
        }
    }



    void LaitaEsineTyhjaanPaikkaan(GameObject esine) {
        for (int iy = 0; iy < inventory.GetLength(0); iy++)
        {
            for (int ix = 0; ix < inventory.GetLength(1); ix++)
            {
                if (inventory[ix, iy] == null)
                {
                    inventory[ix, iy] = esine;
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
        inventory[koordinaatit.x, koordinaatit.y] = null;
    }
}