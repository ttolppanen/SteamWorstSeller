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

    public static RaycastHit[] SortByLenght(RaycastHit[] hits)//Raycasthitit etaisyyden mukaan järjestykseen...
    {
        List<RaycastHit> sortedList = new List<RaycastHit>();
        foreach (RaycastHit hit in hits)
        {
            float distance = hit.distance;
            if (sortedList.Count == 0)
            {
                sortedList.Add(hit);
            }
            else
            {
                for (int i = 0; i < sortedList.Count; i++)
                {
                    if (distance < sortedList[i].distance)
                    {
                        sortedList.Insert(i, hit);
                        break;
                    }
                }
            }
        }
        return sortedList.ToArray();
    }
}
