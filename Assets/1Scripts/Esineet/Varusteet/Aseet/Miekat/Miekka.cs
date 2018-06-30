using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Uusi miekka", menuName = "Esine/Varuste/Ase/Miekka")]
public class Miekka : Ase
{

    public Miekka(string nimi, float vahinko, Sprite kuva, float paino) : base(nimi, kuva, paino, vahinko)
    {

    }

}
