using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANIMPelaajanLyonti : MonoBehaviour {

    GameObject hurtBox;
    GameObject aseenPaikka;
    Transform aseenTrail;
    Torjuminen tScripti;

    private void Start()
    {
        hurtBox = transform.Find("HurtBox").gameObject;
        aseenPaikka = GameObject.Find("AseenPaikka");
        tScripti = GetComponent<Torjuminen>();
    }

    public void SammutaBoxi()
    {
        hurtBox.SetActive(false);
    }
    public void LaitaPaalleBoxi()
    {
        hurtBox.SetActive(true);
    }

    public void AsetaOikeaVerenSuunta(int suunta)//0 eteen, 1 vasemmalle, 2 oikealle, 3 ylös ja 4 alas
    {
        if (suunta == 0)
        {
            hurtBox.GetComponent<HurtBox>().verenSuunta = transform.forward;

        }
        else if (suunta == 1)
        {
            hurtBox.GetComponent<HurtBox>().verenSuunta = -transform.right;

        }
        else if (suunta == 2)
        {
            hurtBox.GetComponent<HurtBox>().verenSuunta = transform.right;
        }
        else if (suunta == 3)
        {
            hurtBox.GetComponent<HurtBox>().verenSuunta = Vector3.up;
        }
        else
        {
            hurtBox.GetComponent<HurtBox>().verenSuunta = Vector3.down - transform.forward;
        }
    }

    public void LaitaPaalleTrail()
    {
        aseenTrail = aseenPaikka.transform.GetChild(0).GetChild(0); //Haetaan aseenpaikan lapsen lapsesta traili
        aseenTrail.gameObject.SetActive(true);
    }
    public void SammutaTrail()
    {
        aseenTrail = aseenPaikka.transform.GetChild(0).GetChild(0); //Haetaan aseenpaikan lapsen lapsesta traili
        aseenTrail.gameObject.SetActive(false);
        aseenTrail.GetComponent<TrailRenderer>().Clear();
    }

    public void TorjuminenAlkaaOikeasti()
    {
        tScripti.torjutaanko = true;
    }
    public void TorjuminenLoppuuOikeasti()
    {
        tScripti.torjutaanko = false;
    }

}
