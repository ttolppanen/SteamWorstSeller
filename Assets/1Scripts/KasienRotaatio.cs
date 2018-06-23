using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KasienRotaatio : MonoBehaviour {

    [Range(0f, 1f)]
    public float rotaatioKerroin;
    Transform kamera;

	void Start () {
        kamera = transform.parent.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        transform.localRotation = kamera.localRotation;
        transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles * rotaatioKerroin);
	}
}
