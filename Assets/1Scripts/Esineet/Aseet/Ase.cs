using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ase : Esine
{

    public float vahinko;
    public Animator animaatiot { get; set; }

    public Ase(string nimi, float vahinko, Sprite kuva) : base(nimi, kuva)
    {
        this.vahinko = vahinko;
    }

    public virtual void Lyo() { }
    public virtual void AloitaTorjuminen() { }
    public virtual void LopetaTorjuminen() { }
}
