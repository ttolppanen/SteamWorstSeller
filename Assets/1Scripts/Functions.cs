using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour {

    public static bool OnWhichSide(Vector3 hereToThere, Vector3 forward) //Millä puolella jokin objecti on, true on samalla puolella kuin forward vektori
    {
        if (Vector3.Dot(hereToThere, forward) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
