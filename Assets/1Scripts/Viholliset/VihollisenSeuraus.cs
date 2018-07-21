using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VihollisenSeuraus : MonoBehaviour {

    public float seuraamisenLopetusAika;
    public bool pitaakoSeurata;
    float aika;
    EnStates states;

    private void Start()
    {
        states = GetComponent<EnStates>();
        pitaakoSeurata = false;
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
