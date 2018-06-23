using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Uusi varuste", menuName = "Esine/Varuste")]
public class Varuste : Esine
{

    public float defence;
    public float paino;
    public VarusteTyyppi varusteTyyppi;

    public Varuste(string nimi, float defence, float paino, Sprite kuva) : base(nimi, kuva)
    {
        this.defence = defence;
        this.paino = paino;
    }
}

public enum VarusteTyyppi { Paa, Rinta, Housut, Hanskat} //Kaulakoru, sormus......