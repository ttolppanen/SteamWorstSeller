using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastMagic : MonoBehaviour {

    //Tämä scripti on kiinni vasemmassa kädessä
    public GameObject spell;
    public float projectileSpeed;

	void Start () {
		
	}
	
	
	void Update () {
        if (Input.GetMouseButton(2))
        {
            Cast();
        }
	}

    public void Cast()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit[] raycastHits = Physics.RaycastAll(ray, Mathf.Infinity);
        raycastHits = Functions.SortByLenght(raycastHits);
        Vector3 hitPosition = transform.position + transform.forward;
        foreach (RaycastHit hit in raycastHits)
        {
            if (hit.transform.tag != "Item" && hit.transform.tag != "Player")
            {
                hitPosition = hit.point;
                break;
            }
        }
        Vector3 castDirection = (hitPosition - transform.position).normalized;
        GameObject spellInstance = Instantiate(spell, transform.position, Quaternion.identity);
        spellInstance.GetComponent<Rigidbody>().AddForce(castDirection * projectileSpeed, ForceMode.Impulse);
    }
}
