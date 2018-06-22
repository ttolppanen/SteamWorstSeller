using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torjuminen : MonoBehaviour {

    public bool torjutaanko;

    private void Update()
    {
        torjutaanko = false;
        if (Input.GetMouseButton(1))
        {
            torjutaanko = true;
        }
    }
}
