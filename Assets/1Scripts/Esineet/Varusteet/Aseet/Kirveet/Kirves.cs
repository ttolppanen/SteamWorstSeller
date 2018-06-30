using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Uusi kirves", menuName = "Esine/Varuste/Ase/Kirves")]
public class Kirves : Ase
{ 

    public Kirves(string nimi, float vahinko, Sprite kuva, float paino) : base(nimi, kuva, paino, vahinko)
    {
    }

}