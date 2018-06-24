using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Uusi panssari", menuName = "Esine/Varuste/Panssari")]
public class Panssari : Varuste
{
    public float defence;

    public Panssari(string nimi, float paino, float defence, Sprite kuva) : base(nimi, paino, kuva)
    {
        this.defence = defence;
    }
}
