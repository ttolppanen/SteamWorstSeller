using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public float doorOpeningForce;
    public float openingDistance;
    public bool isLocked;

    Rigidbody rb;
    HingeJoint hj;
    GameObject player;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        hj = GetComponent<HingeJoint>();
        player = GameManager.instance.player;
        if (isLocked)
        {
            JointLimits jl = hj.limits;
            jl.min = 0;
            jl.max = 0;
            hj.limits = jl;
        }
	}

	void Update ()
    {
        if (Input.GetKeyDown("f") && (player.transform.position - transform.position).magnitude < openingDistance)
        {
            if (isLocked)
            {
                TryToUnlock();
            }
            else
            {
                Open();
            }
        }
	}

    void TryToUnlock()
    {
        foreach (GameObject item in Inventory.instance.inventory)
        {
            if (item != null && item.name == "Key")
            {
                isLocked = false;
                Destroy(item);

                JointLimits jl = hj.limits;
                jl.min = -90;
                jl.max = 90;
                hj.limits = jl;

                return;
            }
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
