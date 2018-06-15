using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANIMPelaajanLyonti : MonoBehaviour {

    GameObject hurtBox;

    private void Start()
    {
        hurtBox = transform.Find("HurtBox").gameObject;
        print(hurtBox.name);
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
