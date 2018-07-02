using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public float doorOpeningForce;
    public float openingDistance;

    Rigidbody rb;
    GameObject player;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        player = GameManager.instance.player;
	}

	void Update ()
    {
        if (Input.GetKeyDown("f") && (player.transform.position - transform.position).magnitude < openingDistance)
        {
            Open();
        }
	}

    void Open()
    {
        bool onWhichSide = Functions.OnWhichSide(player.transform.position - transform.position, transform.parent.forward); //true on oven z akselin osottama suunta, ts. z akselin suunta on etupuoli
        if (onWhichSide)
        {
            rb.AddForce(-transform.forward * doorOpeningForce, ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(transform.forward * doorOpeningForce, ForceMode.Impulse);
        }
    }
}
