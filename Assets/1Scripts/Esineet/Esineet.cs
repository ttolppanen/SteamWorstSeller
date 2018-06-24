using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esine : ScriptableObject{

    public string nimi;
    public Sprite inventoryKuva;
    public float paino;

    public Esine(string nimi, Sprite inventoryKuva, float paino)
    {
        this.nimi = nimi;
        this.inventoryKuva = inventoryKuva;
        this.paino = paino;
    }
}