using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Uusi miekka", menuName = "Esine/Ase/Miekka")]
public class Miekka : Ase
{

    public Miekka(string nimi, float vahinko, Sprite kuva) : base(nimi, vahinko, kuva)
    {

    }

    public override void Lyo()
    {
        animaatiot.SetTrigger("Lyö miekalla");
    }
    public override void AloitaTorjuminen()
    {
        animaatiot.SetBool("Torjutaanko miekalla", true);
    }
    public override void LopetaTorjuminen()
    {
        animaatiot.SetBool("Torjutaanko miekalla", false);
    }
}
