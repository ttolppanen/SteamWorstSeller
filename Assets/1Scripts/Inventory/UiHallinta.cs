using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHallinta : MonoBehaviour {

    public GameObject uiInventory;
    public GameObject esineHiirenKannossa;

	void Update () {
        if (esineHiirenKannossa != null)
        {
            esineHiirenKannossa.transform.position = Input.mousePosition;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (uiInventory.activeSelf)
            {
                uiInventory.SetActive(false);
                if (esineHiirenKannossa != null)
                {
                    esineHiirenKannossa.transform.position = esineHiirenKannossa.transform.parent.transform.position;
                    esineHiirenKannossa = null;
                }
            }
            else
            {
                uiInventory.SetActive(true);
            }
        }		
	}
}
