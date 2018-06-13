using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHallinta : MonoBehaviour {

    public GameObject uiInventory;

	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (uiInventory.activeSelf)
            {
                uiInventory.SetActive(false);
            }
            else
            {
                uiInventory.SetActive(true);
            }
        }		
	}
}
