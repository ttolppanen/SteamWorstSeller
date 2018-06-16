using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Uusi tikari", menuName = "Esine/Ase/Tikari")]
public class Tikari : Ase
{

    public Tikari(string nimi, float vahinko, Sprite kuva) : base(nimi, vahinko, kuva)
    {

    }

    public override void Lyo()
    {
        animaatiot.SetTrigger("Lyö tikarilla");
    }
}