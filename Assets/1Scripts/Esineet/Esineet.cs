using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esine : ScriptableObject{

    public string nimi;
    public Sprite inventoryKuva;

    public Esine(string nimi, Sprite inventoryKuva)
    {
        this.nimi = nimi;
        this.inventoryKuva = inventoryKuva;
    }
}