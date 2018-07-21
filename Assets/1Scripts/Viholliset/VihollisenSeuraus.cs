using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VihollisenSeuraus : MonoBehaviour {

    public float seuraamisenLopetusAika;
    float aika;
    EnStates states;

    private void Start()
    {
        states = GetComponent<EnStates>();
    }

    private void Update()
    {
        if (states.seesPlayer)
        {
            states.isFollowing = true;
            aika = 0;
        }
        else
        {
            if (aika > seuraamisenLopetusAika)
            {
                states.isFollowing = false;
            }
        }
        aika += Time.deltaTime;
    }
}
