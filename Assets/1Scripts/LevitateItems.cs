using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitateItems : MonoBehaviour {

    public float levitationStrength;
    public float scrollWheelSensitivy;

    Transform itemToLevitate;
    float levitationVectorLength;
    float itemsDrag;
	
	// Update is called once per frame
	void Update () {
        if (itemToLevitate == null)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Debug.DrawRay(transform.position, ray.direction);
            RaycastHit[] raycastHits = Physics.RaycastAll(ray, Mathf.Infinity);
            foreach (RaycastHit hit in raycastHits)
            {
                if (hit.transform.tag == "Item")
                {
                    itemToLevitate = hit.transform;
                    levitationVectorLength = (hit.point - transform.position).magnitude;
                    itemsDrag = hit.transform.GetComponent<Rigidbody>().drag;
                    break;
                }
            }
        }
        else
        {
            Rigidbody itemRb = itemToLevitate.GetComponent<Rigidbody>();
            itemRb.drag = 5;
            itemRb.angularDrag = 5;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Vector3 forceDirection = ray.direction * levitationVectorLength + transform.position - itemToLevitate.transform.position;
            itemRb.AddForce(forceDirection * levitationStrength);
            levitationVectorLength += Input.GetAxis("Mouse ScrollWheel") * scrollWheelSensitivy;
        }
    }
}
