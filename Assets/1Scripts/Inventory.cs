using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject[] inventory = new GameObject[10];
    public Transform inventorynPaikka;
    public Transform tiputusPaikka;

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] != null)
                {
                    TiputaInventorysta(i);
                    return;
                }
            }
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Esine" && Input.GetKey("f"))
        {
            Debug.Log("NOH");
            LaitaEsineTyhjaanPaikkaan(other.gameObject);
        }
    }



    void LaitaEsineTyhjaanPaikkaan(GameObject esine) {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = esine;
                inventory[i].transform.parent = inventorynPaikka;
                inventory[i].transform.position = inventorynPaikka.position;
                inventory[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                return;
            }
        }
    }

    void TiputaInventorysta(int indeksi)
    {
        inventory[indeksi].transform.parent = null;
        inventory[indeksi].transform.position = tiputusPaikka.position;
        inventory[indeksi].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        inventory[indeksi] = null;
    }
}
