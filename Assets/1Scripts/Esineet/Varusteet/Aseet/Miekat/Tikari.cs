using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Uusi tikari", menuName = "Esine/Varuste/Ase/Tikari")]
public class Tikari : Ase
{

    public Tikari(string nimi, float vahinko, Sprite kuva, float paino) : base(nimi, kuva, paino, vahinko)
    {

    }

}