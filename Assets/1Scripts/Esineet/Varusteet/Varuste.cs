using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Varuste : Esine
{

    public VarusteTyyppi varusteTyyppi;

    public Varuste(string nimi, float paino, Sprite kuva) : base(nimi, kuva, paino){}

}

public enum VarusteTyyppi { Paa, Rinta, Housut, Hanskat, Ase} //Kaulakoru, sormus......