using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllStats : MonoBehaviour {

    public static AllStats instance;

    //public Dictionary<stats> allStats = new Dictionary<>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
