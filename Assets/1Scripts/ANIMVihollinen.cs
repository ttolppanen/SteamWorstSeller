using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANIMVihollinen : MonoBehaviour {

    GameObject hurtBox;

    private void Start()
    {
        hurtBox = transform.Find("VihollisenHurtBox").gameObject;
    }

    public void SammutaBoxi()
    {
        hurtBox.SetActive(false);
    }
    public void LaitaPaalleBoxi()
    {
        hurtBox.SetActive(true);
    }
}
