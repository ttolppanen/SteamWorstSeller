using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyppy : MonoBehaviour {

    public float hyppyCooldown;
    public float hyppyKorkeus;

    public float kerroinEteen;
    public float kerroinTaakse;
    public float kerroinOikealle_Vasemmalle;

    Rigidbody rb;
    bool saakoHypata;

	void Start () {
        rb = GetComponent<Rigidbody>();
        saakoHypata = true;
	}

	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && saakoHypata)
        {
            Vector3 hyppySuunta = new Vector3(0, hyppyKorkeus, 0);
            if (Input.GetKey("w"))
            {
                hyppySuunta += transform.forward;
                rb.AddForce(hyppySuunta * kerroinEteen, ForceMode.Impulse);
                saakoHypata = false;
                StartCoroutine(hypynCooldown());
            }
            else if (Input.GetKey("s"))
            {
                hyppySuunta += -transform.forward;
                rb.AddForce(hyppySuunta * kerroinTaakse, ForceMode.Impulse);
                saakoHypata = false;
                StartCoroutine(hypynCooldown());
            }
            else if (Input.GetKey("d"))
            {
                hyppySuunta += transform.right;
                rb.AddForce(hyppySuunta * kerroinOikealle_Vasemmalle, ForceMode.Impulse);
                saakoHypata = false;
                StartCoroutine(hypynCooldown());
            }
            else if (Input.GetKey("a"))
            {
                hyppySuunta += -transform.right;
                rb.AddForce(hyppySuunta * kerroinOikealle_Vasemmalle, ForceMode.Impulse);
                saakoHypata = false;
                StartCoroutine(hypynCooldown());
            }

        }
	}

    IEnumerator hypynCooldown()
    {
        yield return new WaitForSeconds(hyppyCooldown);
        saakoHypata = true;
    }
}
