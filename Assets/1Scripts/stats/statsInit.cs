using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class statsInit : MonoBehaviour {
    public enum stats { Health, Strength, Intelligence };
    public int statPool;
    public Dictionary<stats, int> statsTable;

    public void Randomize(Dictionary<stats,int> stats)
    {
        var values = System.Enum.GetValues(typeof(stats));
        foreach(stats i in values)
        {
            stats[i] = 2;
        }

    }

    // Use this for initialization
    void Awake () {
        statsTable = new Dictionary<stats, int>();
        statPool = 2;
        Randomize(statsTable);
	}

    private void Update()
    {

    }
}
