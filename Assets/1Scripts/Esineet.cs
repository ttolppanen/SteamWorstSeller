using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esine : ScriptableObject{

    public string nimi;
    public Sprite kuva;

    public Esine(string nimi, Sprite kuva)
    {
        this.nimi = nimi;
        this.kuva = kuva;
    }
}


public class Ase : Esine {

    public float vahinko;
    public Animator animaatiot { get; set; }

    public Ase(string nimi, float vahinko, Sprite kuva) : base(nimi, kuva)
    {
        this.vahinko = vahinko;
    }

    public virtual void Lyo() { }
}

[CreateAssetMenu(fileName = "Uusi miekka", menuName = "Esine/Ase/Miekka")]
public class Miekka : Ase {

    public Miekka(string nimi, float vahinko, Sprite kuva) : base(nimi ,vahinko, kuva)
    {

    }

    public override void Lyo()
    {
        animaatiot.SetTrigger("Lyö miekalla");
    }
}