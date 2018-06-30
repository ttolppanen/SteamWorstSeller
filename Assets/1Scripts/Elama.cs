using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elama : MonoBehaviour {

    public float maxHP;
    public bool onkoKuollut;
    public float hp;

    private void Start()
    {
        hp = maxHP;
        onkoKuollut = false;
    }

    public void OtaVahinkoa(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            onkoKuollut = true;
        }
    }
}
