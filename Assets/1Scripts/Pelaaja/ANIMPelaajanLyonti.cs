using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANIMPelaajanLyonti : MonoBehaviour {

    GameObject hurtBox;

    private void Start()
    {
        hurtBox = transform.Find("HurtBox").gameObject;
    }

    public void SammutaBoxi()
    {
        hurtBox.SetActive(false);
    }
    public void LaitaPaalleBoxi()
    {
        hurtBox.SetActive(true);
    }
    public void AsetaOikeaVerenSuunta(int suunta)//0 eteen, 1 vasemmalle
    {
        if (suunta == 0)
        {
            hurtBox.GetComponent<HurtBox>().verenSuunta = transform.forward;
            
        }
        else if (suunta == 1)
        {
            hurtBox.GetComponent<HurtBox>().verenSuunta = -transform.right;
            
        }
        else
        {
            hurtBox.GetComponent<HurtBox>().verenSuunta = transform.right;
        }
    }
}
