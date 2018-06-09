using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour {

    public GameObject ruumis;
    public float katsomisRaja;
    Vector3 ruumiinPaikka;
    public float sensitivy;

    void Update() {
        Vector2 muutos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.Rotate(new Vector3(-muutos.y, 0, 0) * sensitivy);
        ruumis.transform.Rotate(new Vector3(0, muutos.x, 0) * sensitivy);
        if (transform.localRotation.eulerAngles.x > katsomisRaja && transform.localRotation.eulerAngles.x < 180)
        {
            transform.localRotation = Quaternion.Euler(katsomisRaja, 0, 0);
        }
        if (transform.localRotation.eulerAngles.x < (360 - katsomisRaja) && transform.localRotation.eulerAngles.x > 180)
        {
            transform.localRotation = Quaternion.Euler(-katsomisRaja, 0, 0);
        }
    }
}
