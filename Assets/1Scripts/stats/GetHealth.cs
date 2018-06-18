using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHealth : MonoBehaviour {
    private int stat;
    private int statChange;

    public Text text;
    private GameObject player;
    public statsInit.stats type;
    private int statPool;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Cube");
        

        statsInit statFFU = player.GetComponent<statsInit>();
        statPool = statFFU.statPool;
        int fuck = statFFU.statsTable[type];
        stat = fuck;
        statChange = 0;
        text.text = stat.ToString();
    }

    private void Update()
    {
        statsInit statFFU = player.GetComponent<statsInit>();
        stat = statFFU.statsTable[type];
        int what = stat + statChange;
        text.text = what.ToString();
    }

    public void add()
    {
        player = GameObject.Find("Cube");
        statsInit statFFU = player.GetComponent<statsInit>();
        statPool = statFFU.statPool;

        if (statPool>0)
        {
            stat++;
            statChange++;
            text.text = stat.ToString();
            statFFU.statPool -= 1;
            statPool--;
        }
    }

    public void reduce()
    {
        if(statChange>0)
        {
            statsInit statFFU = player.GetComponent<statsInit>();
            statFFU.statPool+=1;
            stat--;
            statChange--;
            text.text = stat.ToString();
            statPool++;
        }
    }

    public void Reset()
    {
        stat -= statChange;
        statChange = 0;
        text.text = stat.ToString();
    }

    public void Allocate()
    {
        player.GetComponent<statsInit>().statsTable[type] += statChange;
        statChange = 0;
    }

}
