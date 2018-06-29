using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ase : Varuste
{

    public float vahinko;
    public VahinkoTyyppi vahinkoTyyppi;
    public Animator animaatiot { get; set; }

    public Ase(string nimi, Sprite kuva, float paino, float vahinko) : base(nimi, paino, kuva)
    {
        this.vahinko = vahinko;
    }

    public virtual void Lyo() { }
    public virtual void AloitaTorjuminen() { }
    public virtual void LopetaTorjuminen() { }
}

public enum VahinkoTyyppi {Viilto, tylppa, pistava}
