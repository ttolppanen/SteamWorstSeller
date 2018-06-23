using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyppy : MonoBehaviour {

    public float hyppyCooldown;
    public float hyppyKorkeus;
    public float staminaMaksu;

    public float kerroinEteen;
    public float kerroinTaakse;
    public float kerroinOikealle_Vasemmalle;

    Rigidbody rb;
    Stamina sScripti;
    bool saakoHypata;

	void Start () {
        rb = GetComponent<Rigidbody>();
        saakoHypata = true;
        sScripti = GetComponent<Stamina>();
	}

	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && saakoHypata && sScripti.SaadaankoKayttaaStaminaa(staminaMaksu))
        {
            Vector3 hyppySuunta = new Vector3(0, hyppyKorkeus, 0);

            if (Input.GetKey("w"))
            {
                hyppySuunta += transform.forward;
                rb.AddForce(hyppySuunta * kerroinEteen, ForceMode.Impulse);
            }
            else if (Input.GetKey("s"))
            {
                hyppySuunta += -transform.forward;
                rb.AddForce(hyppySuunta * kerroinTaakse, ForceMode.Impulse);
            }
            else if (Input.GetKey("d"))
            {
                hyppySuunta += transform.right;
                rb.AddForce(hyppySuunta * kerroinOikealle_Vasemmalle, ForceMode.Impulse);
            }
            else if (Input.GetKey("a"))
            {
                hyppySuunta += -transform.right;
                rb.AddForce(hyppySuunta * kerroinOikealle_Vasemmalle, ForceMode.Impulse);
            }

            saakoHypata = false;
            StartCoroutine(hypynCooldown());
            sScripti.VahennaStaminaa(staminaMaksu);
        }
	}

    IEnumerator hypynCooldown()
    {
        yield return new WaitForSeconds(hyppyCooldown);
        saakoHypata = true;
    }
}
