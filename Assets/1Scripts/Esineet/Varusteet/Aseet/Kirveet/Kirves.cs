using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Uusi kirves", menuName = "Esine/Varuste/Ase/Kirves")]
public class Kirves : Ase
{

    public Kirves(string nimi, float vahinko, Sprite kuva, float paino) : base(nimi, kuva, paino, vahinko)
    {

    }

    public override void Lyo()
    {
        animaatiot.SetTrigger("Lyö kirveellä");
    }
    public override void AloitaTorjuminen()
    {
        animaatiot.SetBool("Torjutaanko kirveellä", true);
    }
    public override void LopetaTorjuminen()
    {
        animaatiot.SetBool("Torjutaanko kirveellä", false);
    }
}