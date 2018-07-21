using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnStates : MonoBehaviour {

    public bool isIdle;
    public bool isFollowing;
    public bool seesPlayer;
    public bool inHittingRange;
    public bool isReturning;

    private void Awake()
    {
        isIdle = true;
        isFollowing = false;
        seesPlayer = false;
        inHittingRange = false;
        isReturning = false;
    }

    private void Update()
    {
        if (!isFollowing && !isReturning)
        {
            isIdle = true;
        }
        else
        {
            isIdle = false;
        }
    }
}
