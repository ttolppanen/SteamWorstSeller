using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour {

	public GameObject ruumis;
	Vector3 paikkaViimeksi;
	Vector3 ruumiinPaikka;
	public float sensitivy;
	
	// Update is called once per frame
	void Update () {
		Vector2 muutos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
		transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles + sensitivy * new Vector3 (-muutos.y, 0, 0));
		ruumis.transform.rotation = Quaternion.Euler (ruumis.transform.rotation.eulerAngles + sensitivy * new Vector3 (0, muutos.x, 0));
	}
}
