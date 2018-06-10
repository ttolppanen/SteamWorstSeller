using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject[,] inventory = new GameObject[10, 10];
    public Transform inventorynPaikka;
    public Transform tiputusPaikka;

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            for (int ix = 0; ix < inventory.GetLength(0); ix++)
            {
                for (int iy = 0; iy < inventory.GetLength(1); iy++)
                {
                    if (inventory[ix, iy] != null)
                    {
                        TiputaInventorysta(ix, iy);
                        return;
                    }
                }
            }
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Esine" && Input.GetKey("f"))
        {
            LaitaEsineTyhjaanPaikkaan(other.gameObject);
        }
    }



    void LaitaEsineTyhjaanPaikkaan(GameObject esine) {
        for (int ix = 0; ix < inventory.GetLength(0); ix++)
        {
            for (int iy = 0; iy < inventory.GetLength(1); iy++)
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

    void TiputaInventorysta(int indeksi1, int indeksi2)
    {
        inventory[indeksi1, indeksi2].transform.parent = null;
        inventory[indeksi1, indeksi2].transform.position = tiputusPaikka.position;
        inventory[indeksi1, indeksi2].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        inventory[indeksi1, indeksi2] = null;
    }
}
