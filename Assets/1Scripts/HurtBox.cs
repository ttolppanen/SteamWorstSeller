using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour {

    public float vahinko;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Elama>().OtaVahinkoa(vahinko);
            gameObject.SetActive(false);
        }
    }
}
