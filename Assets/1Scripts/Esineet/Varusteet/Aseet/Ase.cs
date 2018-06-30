using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ase : Varuste
{

    public float vahinko;
    public VahinkoTyyppi vahinkoTyyppi;
    public AseTyyppi aseTyyppi;
    public Animator animaatiot { get; set; }

    public Ase(string nimi, Sprite kuva, float paino, float vahinko) : base(nimi, paino, kuva)
    {
        this.vahinko = vahinko;
    }

    public void Lyo() { animaatiot.SetTrigger("Lyö"); }
    public virtual void AloitaTorjuminen() { animaatiot.SetBool("Torjutaanko", true); }
    public virtual void LopetaTorjuminen() { animaatiot.SetBool("Torjutaanko", false); }
}

public enum VahinkoTyyppi {Viilto, tylppa, pistava}
public enum AseTyyppi {Kadet, Kevyt, KeskiRaskas, Raskas} // Paremmat nimet...
