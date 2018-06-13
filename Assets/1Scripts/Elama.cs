using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elama : MonoBehaviour {

    public float maxHP;
    public bool onkoKuollut;
    float hp;

    private void Start()
    {
        hp = maxHP;
        onkoKuollut = false;
    }

    public void OtaVahinkoa(float vahinko)
    {
        hp -= vahinko;
        if (hp <= 0)
        {
            onkoKuollut = true;
        }
    }
}
