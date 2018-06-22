using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VihollistenHurtBox : MonoBehaviour {

    public float vahinko;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PelaajanElama>().OtaVahinkoa(vahinko);
            gameObject.SetActive(false);
        }
    }
}