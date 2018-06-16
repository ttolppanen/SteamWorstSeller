using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoihdunFlicker : MonoBehaviour {

    public float flickkausAika;
    public float flickkausMaara;

    Light valo;
    float intensityAlussa;
    float aika;

	void Start () {
        valo = GetComponent<Light>();
        intensityAlussa = valo.intensity;
	}
	
	// Update is called once per frame
	void Update () {
        if (aika >= flickkausAika)
        {
            aika = 0;
            valo.intensity = intensityAlussa + Random.Range(0f, flickkausMaara * 2) - flickkausMaara;
        }
        aika += Time.deltaTime;
	}
}
