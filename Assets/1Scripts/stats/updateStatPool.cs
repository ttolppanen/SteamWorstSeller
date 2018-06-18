using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateStatPool : MonoBehaviour {
    public int statPool;
    public Text text;
	// Use this for initialization
	void Start () {
        
        GameObject player = GameObject.Find("Cube");
        statPool = player.GetComponent<statsInit>().statPool;
        text.text = "Statpool: " + statPool.ToString();
        
	}
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.Find("Cube");
        statPool = player.GetComponent<statsInit>().statPool;
        text.text = "Statpool: " + statPool.ToString();
    }
}
