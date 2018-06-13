using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyoVihollista : MonoBehaviour {

	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Animator animaatiot = GetComponent<Animator>();
            animaatiot.SetTrigger("Lyö");
        }	
	}
}
