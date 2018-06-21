using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class katsoPelaajaPain : MonoBehaviour {

    GameObject kamera;

	void Start () {
        kamera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(kamera.transform);
	}
}
